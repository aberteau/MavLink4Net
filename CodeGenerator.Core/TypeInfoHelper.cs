using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    public class TypeInfoHelper
    {
        public static string GetFilename(TypeInfo typeInfo)
        {
            return $"{typeInfo.Name}.cs";
        }

        public static TypeInfo GetSerializerFactoryTypeInfo()
        {
            string serializerFactoryClassName = "MessageSerializerFactory";
            TypeInfo typeInfo = new Core.TypeInfo()
            {
                Name = serializerFactoryClassName,
                Namespace = ConstantHelper.Namespaces.Root_Messages_Serialization
            };
            return typeInfo;
        }

        public static TypeInfo GetMessageFactoryTypeInfo()
        {
            string className = "MessageFactory";
            TypeInfo typeInfo = new Core.TypeInfo()
            {
                Name = className,
                Namespace = ConstantHelper.Namespaces.Root_Messages
            };
            return typeInfo;
        }

        public static TypeInfo GetSerializerInterfaceTypeInfo()
        {
            string serializerInterfaceName = "IMessageSerializer";
            Core.TypeInfo typeInfo = new Core.TypeInfo()
            {
                Name = serializerInterfaceName,
                Namespace = ConstantHelper.Namespaces.Root_Messages_Serialization
            };
            return typeInfo;
        }

        public static TypeInfo GetMavMessageTypeTypeInfo()
        {
            var mavMessageTypeEnumName = "MavMessageType";
            Core.TypeInfo typeInfo = new Core.TypeInfo()
            {
                Name = mavMessageTypeEnumName,
                Namespace = ConstantHelper.Namespaces.Root_Messages
            };
            return typeInfo;
        }

        public static TypeInfo GetMessageClassTypeInfo()
        {
            string messageBaseClassName = "Message";

            TypeInfo typeInfo = new Core.TypeInfo()
            {
                Name = messageBaseClassName,
                Namespace = ConstantHelper.Namespaces.Root_Messages
            };
            return typeInfo;
        }

        public static TypeInfo GetMessageInterfaceTypeInfo()
        {
            string messageBaseClassName = "IMessage";

            TypeInfo typeInfo = new Core.TypeInfo()
            {
                Name = messageBaseClassName,
                Namespace = ConstantHelper.Namespaces.Root_Messages
            };
            return typeInfo;
        }

        public static TypeInfo GetTypeInfo(string ns, Message message)
        {
            TypeInfo typeInfo = new TypeInfo()
            {
                Name = NameHelper.GetMessageClassName(message),
                Namespace = ns
            };

            return typeInfo;
        }
    }
}
