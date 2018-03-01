using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    public class MessageFieldTypeMapper
    {
        public static string ToPrimitiveRawType(MessageFieldType type)
        {
            return MessageFieldDataTypeMapper.ToRawDataType(type.DataType);
        }

        public static string ToArrayRawType(MessageFieldType type)
        {
            int arrayLength = type.ArrayLength;
            string rawDataType = MessageFieldDataTypeMapper.ToRawDataType(type.DataType);
            string arrayRawType = $"{rawDataType}[{arrayLength}]";
            return arrayRawType;
        }

        public static string ToEnumRawType(Data.Enum pEnum)
        {
            return $"{pEnum.Name} enum"; ;
        }
    }
}
