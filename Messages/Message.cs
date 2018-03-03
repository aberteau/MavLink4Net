using System;

namespace MavLink4Net.Messages
{
    public class Message
        : IMessage
    {
        public MavMessageType MavType { get; }

        protected Message(MavMessageType mavType)
        {
            MavType = mavType;
        }
    }
}
