//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MavLink4Net.Messages.Serialization.Common
{
    
    
    public class DataTransmissionHandshakeMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.DataTransmissionHandshakeMessage tMessage = message as MavLink4Net.Messages.Common.DataTransmissionHandshakeMessage;
            writer.Write(tMessage.Size);
            writer.Write(tMessage.Width);
            writer.Write(tMessage.Height);
            writer.Write(tMessage.Packets);
            writer.Write(tMessage.Type);
            writer.Write(tMessage.Payload);
            writer.Write(tMessage.JpgQuality);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.DataTransmissionHandshakeMessage message = new MavLink4Net.Messages.Common.DataTransmissionHandshakeMessage();
            message.Size = reader.ReadUInt32();
            message.Width = reader.ReadUInt16();
            message.Height = reader.ReadUInt16();
            message.Packets = reader.ReadUInt16();
            message.Type = reader.ReadByte();
            message.Payload = reader.ReadByte();
            message.JpgQuality = reader.ReadByte();
            return message;
        }
    }
}
