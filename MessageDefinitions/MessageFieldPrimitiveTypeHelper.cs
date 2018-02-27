using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions
{
    public class MessageFieldPrimitiveTypeHelper
    {
        public static Type GetCSharpType(MessageFieldPrimitiveType t)
        {
            switch (t)
            {
                case MessageFieldPrimitiveType.Float32:
                    return typeof(float);
                case MessageFieldPrimitiveType.Int8:
                    return typeof(SByte);
                case MessageFieldPrimitiveType.UInt8:
                    return typeof(byte);
                case MessageFieldPrimitiveType.Int16:
                    return typeof(Int16);
                case MessageFieldPrimitiveType.UInt16:
                    return typeof(UInt16);
                case MessageFieldPrimitiveType.Int32:
                    return typeof(Int32);
                case MessageFieldPrimitiveType.UInt32:
                    return typeof(UInt32);
                case MessageFieldPrimitiveType.Int64:
                    return typeof(Int64);
                case MessageFieldPrimitiveType.UInt64:
                    return typeof(UInt64);
                case MessageFieldPrimitiveType.Char:
                    return typeof(char);
                case MessageFieldPrimitiveType.Double:
                    return typeof(double);
                default:
                    return null;
            }
        }
    }
}
