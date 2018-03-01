using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class MessageFieldTypeMapper
    {
        public static MessageFieldDataType ToDataType(string type)
        {
            string basicType = ToRawDataType(type);

            switch (basicType)
            {
                case "float":
                    return MessageFieldDataType.Float32;
                case "int8_t":
                    return MessageFieldDataType.Int8;
                case "uint8_t":
                case "uint8_t_mavlink_version":
                    return MessageFieldDataType.UInt8;
                case "int16_t":
                    return MessageFieldDataType.Int16;
                case "uint16_t":
                    return MessageFieldDataType.UInt16;
                case "int32_t":
                    return MessageFieldDataType.Int32;
                case "uint32_t":
                    return MessageFieldDataType.UInt32;
                case "int64_t":
                    return MessageFieldDataType.Int64;
                case "uint64_t":
                    return MessageFieldDataType.UInt64;
                case "char":
                    return MessageFieldDataType.Char;
                case "double":
                    return MessageFieldDataType.Double;
                default:
                    return MessageFieldDataType.None;
            }
        }

        public static String ToRawDataType(MessageFieldDataType dataType)
        {
            switch (dataType)
            {
                case MessageFieldDataType.Float32:
                    return "float";
                case MessageFieldDataType.Int8:
                    return "int8_t";
                case MessageFieldDataType.UInt8:
                    return "uint8_t";
                case MessageFieldDataType.Int16:
                    return "int16_t";
                case MessageFieldDataType.UInt16:
                    return "uint16_t";
                case MessageFieldDataType.Int32:
                    return "int32_t";
                case MessageFieldDataType.UInt32:
                    return "uint32_t";
                case MessageFieldDataType.Int64:
                    return "int64_t";
                case MessageFieldDataType.UInt64:
                    return "uint64_t";
                case MessageFieldDataType.Char:
                    return "char";
                case MessageFieldDataType.Double:
                    return "double";
                default:
                    return null;
            }
        }

        public static string ToRawDataType(string rawFieldType)
        {
            string[] tt = rawFieldType.Split('[', ']');

            if (tt.Length == 0)
                return "";

            string result = tt[0];
            return result;
        }

        public static bool IsArray(string rawFieldType)
        {
            bool isArray = rawFieldType.Contains("[");
            return isArray;
        }
    }
}
