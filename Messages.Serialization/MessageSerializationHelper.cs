using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MavLink4Net.Messages.Serialization
{
    class MessageSerializationHelper
    {
        private static IMessageSerializer CreateSerializer(MavMessageType mavType)
        {
            IMessageSerializer serializer = MessageSerializerFactory.CreateSerializer(mavType);
            return serializer;
        }

        public static void Serialize(BinaryWriter writer, IMessage message)
        {
            IMessageSerializer serializer = CreateSerializer(message.MavType);
            serializer?.Serialize(writer, message);
        }

        public static IMessage Deserialize(BinaryReader reader, MavMessageType mavType)
        {
            IMessageSerializer serializer = CreateSerializer(mavType);
            IMessage message = serializer?.Deserialize(reader);
            return message;
        }
    }
}
