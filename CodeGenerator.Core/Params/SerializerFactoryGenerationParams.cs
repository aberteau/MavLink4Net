using System;

namespace MavLink4Net.CodeGenerator.Core.Params
{
    public class SerializerFactoryGenerationParams
    {
        public String OutputFilePath { get; set; }

        public TypeInfo TypeInfo { get; set; }

        public String SerializerNamespace { get; set; }

        public TypeInfo MessageTypeEnumTypeInfo { get; set; }

        public TypeInfo SerializerInterfaceTypeInfo { get; set; }
    }
}
