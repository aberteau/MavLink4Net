using System;

namespace MavLink4Net.CodeGenerator.Core.Params
{
    public class MessageFactoryGenerationParams
    {
        public String OutputFilePath { get; set; }

        public TypeInfo TypeInfo { get; set; }

        public String CommonMessagesNamespace { get; set; }

        public TypeInfo MessageTypeEnumTypeInfo { get; set; }

        public TypeInfo MessageInterfaceTypeInfo { get; set; }
    }
}
