using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class MessageFieldType
    {
        public MessageFieldPrimitiveType PrimitiveType { get; set; }

        public Int32 ArrayLength { get; set; }

        public string Enum { get; set; }

        public bool IsEnum => !string.IsNullOrWhiteSpace(Enum);

        public bool IsArray => ArrayLength > 0;

        public Int32 TypeLength { get; set; }

        public Int32 WireLength => IsArray ? ArrayLength * TypeLength : TypeLength;
    }
}
