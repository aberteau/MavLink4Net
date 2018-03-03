using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MavLink4Net.Messages.Serialization
{
    class PacketSerializer
    {
        public static Packet Deserialize(BinaryReader reader)
        {
            Packet packet = new Packet()
            {
                PayLoadLength = reader.ReadByte(),
                PacketSequenceNumber = reader.ReadByte(),
                SystemId = reader.ReadByte(),
                ComponentId = reader.ReadByte(),
                MessageId = reader.ReadByte(),
            };

            // Read the payload instead of deserializing so we can validate CRC.
            packet.Payload = reader.ReadBytes(packet.PayLoadLength);
            packet.Checksum1 = reader.ReadByte();
            packet.Checksum2 = reader.ReadByte();

            if (packet.IsValidCrc())
            {
                packet.DeserializeMessage();
            }

            return packet;
        }

        private void DeserializeMessage()
        {
            UasMessage result = UasSummary.CreateFromId(MessageId);

            if (result == null) return;  // Unknown type

            using (MemoryStream ms = new MemoryStream(Payload))
            {
                using (BinaryReader br = GetBinaryReader(ms))
                {
                    result.DeserializeBody(br);
                }
            }

            Message = result;
            IsValid = true;
        }

        public static BinaryReader GetBinaryReader(Stream s)
        {
            return new BinaryReader(s, Encoding.ASCII);
        }


        // __ Serialization ___________________________________________________


        public static MavLinkPacket GetPacketForMessage(
            UasMessage msg, byte systemId, byte componentId, byte sequenceNumber)
        {
            MavLinkPacket result = new MavLinkPacket()
            {
                SystemId = systemId,
                ComponentId = componentId,
                PacketSequenceNumber = sequenceNumber,
                MessageId = msg.MessageId,
                Message = msg
            };

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    msg.SerializeBody(bw);
                }

                result.Payload = ms.ToArray();
                result.PayLoadLength = (byte)result.Payload.Length;
                result.UpdateCrc();
            }

            return result;
        }
    }
}
