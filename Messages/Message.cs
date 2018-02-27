using System;

namespace MavLink4Net.Messages
{
    public class Message
    {
        public MavType MavType { get; }

        protected Message(MavType mavType)
        {
            MavType = mavType;
        }
    }
}
