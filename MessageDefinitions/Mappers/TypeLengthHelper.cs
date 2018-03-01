using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class TypeLengthHelper
    {
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
    }
}
