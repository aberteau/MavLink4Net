using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class TypeLengthHelper
    {
        public static Int32 GetTypeLength(MessageFieldPrimitiveType type)
        {
            switch (type)
            {
                case MessageFieldPrimitiveType.Float32:
                    return 4;
                case MessageFieldPrimitiveType.Int8:
                    return 1;
                case MessageFieldPrimitiveType.UInt8:
                    return 1;
                case MessageFieldPrimitiveType.Int16:
                    return 2;
                case MessageFieldPrimitiveType.UInt16:
                    return 2;
                case MessageFieldPrimitiveType.Int32:
                    return 4;
                case MessageFieldPrimitiveType.UInt32:
                    return 4;
                case MessageFieldPrimitiveType.Int64:
                    return 8;
                case MessageFieldPrimitiveType.UInt64:
                    return 8;
                case MessageFieldPrimitiveType.Char:
                    return 1;
                case MessageFieldPrimitiveType.Double:
                    return 8;
                default:
                    return 4;
            }
        }
    }
}
