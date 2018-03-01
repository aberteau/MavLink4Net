using System;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    public class SystemTypeHelper
    {
        public static Type GetType(MessageFieldDataType dataType)
        {
            switch (dataType)
            {
                case MessageFieldDataType.Float32:
                    return typeof(float);
                case MessageFieldDataType.Int8:
                    return typeof(SByte);
                case MessageFieldDataType.UInt8:
                    return typeof(byte);
                case MessageFieldDataType.Int16:
                    return typeof(Int16);
                case MessageFieldDataType.UInt16:
                    return typeof(UInt16);
                case MessageFieldDataType.Int32:
                    return typeof(Int32);
                case MessageFieldDataType.UInt32:
                    return typeof(UInt32);
                case MessageFieldDataType.Int64:
                    return typeof(Int64);
                case MessageFieldDataType.UInt64:
                    return typeof(UInt64);
                case MessageFieldDataType.Char:
                    return typeof(char);
                case MessageFieldDataType.Double:
                    return typeof(double);
                default:
                    return null;
            }
        }
    }
}
