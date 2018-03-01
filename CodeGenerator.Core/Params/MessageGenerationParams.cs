using System;

namespace MavLink4Net.CodeGenerator.Core.Params
{
    public class MessageGenerationParams
    {
        public String OutputPath { get; set; }

        public String Namespace { get; set; }

        public TypeInfo BaseClassTypeInfo { get; set; }

        public TypeInfo MessageTypeEnumTypeInfo { get; set; }
    }
}
