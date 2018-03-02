using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class MessageFieldType
    {
        public MessageFieldDataType DataType { get; }

        public FieldType FieldType { get; }

        public Int32 ArrayLength { get; }

        public Data.Enum Enum { get; }

        public Int32 TypeLength { get; }

        public Int32 WireLength => FieldType == FieldType.Array ? ArrayLength * TypeLength : TypeLength;

        protected MessageFieldType(FieldType fieldType, MessageFieldDataType dataType, int typeLength)
        {
            FieldType = fieldType;
            DataType = dataType;
            TypeLength = typeLength;
        }

        public MessageFieldType(MessageFieldDataType dataType, int typeLength)
            : this(FieldType.Primitive, dataType, typeLength)
        { }

        public MessageFieldType(MessageFieldDataType dataType, int typeLength, Enum pEnum)
            : this(FieldType.Enum, dataType, typeLength)
        {
            Enum = pEnum;
        }

        public MessageFieldType(MessageFieldDataType dataType, int typeLength, int arrayLength)
            : this(FieldType.Array, dataType, typeLength)
        {
            ArrayLength = arrayLength;
        }
    }
}
