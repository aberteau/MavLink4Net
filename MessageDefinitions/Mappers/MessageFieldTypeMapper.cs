using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class MessageFieldTypeMapper
    {
        public static MessageFieldPrimitiveType ToFieldPrimitiveType(string type)
        {
            string basicType = GetBasicFieldTypeFromString(type);

            switch (basicType)
            {
                case "float":
                    return MessageFieldPrimitiveType.Float32;
                case "int8_t":
                    return MessageFieldPrimitiveType.Int8;
                case "uint8_t":
                case "uint8_t_mavlink_version":
                    return MessageFieldPrimitiveType.UInt8;
                case "int16_t":
                    return MessageFieldPrimitiveType.Int16;
                case "uint16_t":
                    return MessageFieldPrimitiveType.UInt16;
                case "int32_t":
                    return MessageFieldPrimitiveType.Int32;
                case "uint32_t":
                    return MessageFieldPrimitiveType.UInt32;
                case "int64_t":
                    return MessageFieldPrimitiveType.Int64;
                case "uint64_t":
                    return MessageFieldPrimitiveType.UInt64;
                case "char":
                    return MessageFieldPrimitiveType.Char;
                case "double":
                    return MessageFieldPrimitiveType.Double;
                default:
                    return MessageFieldPrimitiveType.None;
            }
        }

        public static String GetBasicFieldType(MessageFieldPrimitiveType t)
        {
            switch (t)
            {
                case MessageFieldPrimitiveType.Float32:
                    return "float";
                case MessageFieldPrimitiveType.Int8:
                    return "int8_t";
                case MessageFieldPrimitiveType.UInt8:
                    return "uint8_t";
                case MessageFieldPrimitiveType.Int16:
                    return "int16_t";
                case MessageFieldPrimitiveType.UInt16:
                    return "uint16_t";
                case MessageFieldPrimitiveType.Int32:
                    return "int32_t";
                case MessageFieldPrimitiveType.UInt32:
                    return "uint32_t";
                case MessageFieldPrimitiveType.Int64:
                    return "int64_t";
                case MessageFieldPrimitiveType.UInt64:
                    return "uint64_t";
                case MessageFieldPrimitiveType.Char:
                    return "char";
                case MessageFieldPrimitiveType.Double:
                    return "double";
                default:
                    return null;
            }
        }

        public static string GetBasicFieldTypeFromString(string t)
        {
            string[] tt = t.Split('[', ']');

            if (tt.Length == 0)
                return "";

            string result = tt[0];
            return result;
        }
    }
}
