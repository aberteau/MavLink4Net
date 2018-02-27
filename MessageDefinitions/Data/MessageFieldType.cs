using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class MessageFieldType
    {
        public MessageFieldPrimitiveType PrimitiveType { get; set; }

        public Int32 ArraySize { get; set; }

        public string Enum { get; set; }

        public bool IsEnum => !string.IsNullOrWhiteSpace(Enum);

        public bool IsArray => ArraySize > 0;
    }
}
