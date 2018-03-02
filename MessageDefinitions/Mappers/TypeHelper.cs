using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    public class TypeHelper
    {
        public static string TranslatePrimitiveRawType(String type)
        {
            if (type.Equals("uint8_t_mavlink_version"))
                return "uint8_t";

            return type;
        }

        public static MessageFieldDataType ToDataType(string type)
        {
            string basicType = ToRawDataType(type);

            switch (basicType)
            {
                case "float":
                    return MessageFieldDataType.Float32;
                case "array":
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

        public static int GetArraySize(string t)
        {
            string[] tt = t.Split('[', ']');
            if (tt.Length > 1)
                return ParseToInt(tt[1]);

            return 0;
        }

        private static int ParseToInt(string str, int defaultValue = -1)
        {
            if (int.TryParse(str, out var result))
                return result;

            return defaultValue;
        }

        public static Int32 GetTypeLength(Xml.MessageField xMessageField)
        {
            MessageFieldDataType dataType = ToDataType(xMessageField.Type);
            int typeLength = GetTypeLength(dataType);
            return typeLength;
        }

        public static Int32 GetTypeLength(MessageFieldDataType type)
        {
            switch (type)
            {
                case MessageFieldDataType.Float32:
                    return 4;
                case MessageFieldDataType.Int8:
                    return 1;
                case MessageFieldDataType.UInt8:
                    return 1;
                case MessageFieldDataType.Int16:
                    return 2;
                case MessageFieldDataType.UInt16:
                    return 2;
                case MessageFieldDataType.Int32:
                    return 4;
                case MessageFieldDataType.UInt32:
                    return 4;
                case MessageFieldDataType.Int64:
                    return 8;
                case MessageFieldDataType.UInt64:
                    return 8;
                case MessageFieldDataType.Char:
                    return 1;
                case MessageFieldDataType.Double:
                    return 8;
                default:
                    return 4;
            }
        }

        public static string ToEnumRawType(Data.MessageField pEnum)
        {
            return $"{pEnum.XmlDefinition.Enum} enum"; ;
        }
    }
}
