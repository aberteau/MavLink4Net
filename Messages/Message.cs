using System;

namespace MavLink4Net.Messages
{
    public class Message
        : IMessage
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
