using System;

namespace MavLink4Net.Messages
{
    public class Message
    {
        public MavMessageType MavType { get; }

        public byte CrcExtra { get; }

        protected Message(MavMessageType mavType, byte crcExtra)
        {
            MavType = mavType;
            CrcExtra = crcExtra;
        }
    }
}
