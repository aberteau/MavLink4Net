using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class MessageFieldType
    {
        public String RawString { get; }

        public MessageFieldDataType DataType { get; }

        public FieldType FieldType { get; }

        public Int32 ArrayLength { get; }

        public Data.Enum Enum { get; }

        public Int32 TypeLength { get; }

        public Int32 WireLength => FieldType == FieldType.Array ? ArrayLength * TypeLength : TypeLength;

        protected MessageFieldType(string rawString, FieldType fieldType, MessageFieldDataType dataType, int typeLength)
        {
            FieldType = fieldType;
            DataType = dataType;
            TypeLength = typeLength;
            RawString = rawString;
        }

        public MessageFieldType(string rawString, MessageFieldDataType dataType, int typeLength)
            : this(rawString, FieldType.Primitive, dataType, typeLength)
        { }

        public MessageFieldType(string rawString, MessageFieldDataType dataType, int typeLength, Enum pEnum)
            : this(rawString, FieldType.Enum, dataType, typeLength)
        {
            Enum = pEnum;
        }

        public MessageFieldType(string rawString, MessageFieldDataType dataType, int typeLength, int arrayLength)
            : this(rawString, FieldType.Array, dataType, typeLength)
        {
            ArrayLength = arrayLength;
        }
    }
}
