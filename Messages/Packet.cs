using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.Messages
{
    public class Packet
    {
        public const int PacketOverheadNumBytes = 7;

        public byte PayLoadLength;
        public byte PacketSequenceNumber;
        public byte SystemId;
        public byte ComponentId;
        public byte MessageId;
        public byte[] Payload;
        public byte Checksum1;
        public byte Checksum2;
    }
}
