using System;

namespace MavLink4Net.Messages
{
    public class Message
    {
        public MavMessageType MavType { get; }

        protected Message(MavMessageType mavType)
        {
            MavType = mavType;
        }
    }
}
