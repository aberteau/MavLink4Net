using System;

namespace MavLink4Net.CodeGenerator.Core.Params
{
    public class SerializerGenerationParams
    {
        public String OutputPath { get; set; }

        public String Namespace { get; set; }

        public String MessagesNamespace { get; set; }

        public TypeInfo BaseClassTypeInfo { get; set; }

        public TypeInfo SerializerInterfaceTypeInfo { get; set; }
    }
}
