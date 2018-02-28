using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class NameHelper
    {
        public static string GetMessageClassName(Message message)
        {
            string messageClassName = $"{message.Name}Message";
            return messageClassName;
        }

        public static string GetSerializerClassName(Message message)
        {
            string messageName = GetMessageClassName(message);
            string serializerClassName = $"{messageName}Serializer";
            return serializerClassName;
        }
    }
}
