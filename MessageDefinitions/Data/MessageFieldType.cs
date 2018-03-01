using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class MessageFieldType
    {
        public MessageFieldDataType DataType { get; set; }

        public Int32 ArrayLength { get; set; }

        public Data.Enum Enum { get; set; }

        public bool IsEnum => Enum != null;

        public bool IsArray => ArrayLength > 0;

        public Int32 TypeLength { get; set; }

        public Int32 WireLength => IsArray ? ArrayLength * TypeLength : TypeLength;
    }
}
