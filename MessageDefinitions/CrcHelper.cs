using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MavLink4Net.MessageDefinitions.Mappers;
using MavLink4Net.MessageDefinitions.Xml;

namespace MavLink4Net.MessageDefinitions
{
    public class CrcHelper
    {
        public static byte GetExtraCrc(string xMessageName, IEnumerable<MessageField> xMessageFields)
        {
            UInt16 crc = GetCrc(xMessageName + ' ');

            IList<MessageFieldCrcData> fieldCrcDatas = ToMessageFieldCrcDatas(xMessageFields);

            foreach (MessageFieldCrcData fieldCrcData in fieldCrcDatas.OrderByDescending(t => t.TypeLength).ThenBy(t => t.DefinitionIndex).ToList())
            {
                String translatedRawType = TypeHelper.TranslatePrimitiveRawType(fieldCrcData.Field.Type);
                string rawDataType = TypeHelper.ToRawDataType(translatedRawType);
                crc = GetCrc(rawDataType + ' ', crc);
                crc = GetCrc(fieldCrcData.Field.Name + ' ', crc);

                if (fieldCrcData.ArrayLength > 1)
                    crc = GetCrc((byte)fieldCrcData.ArrayLength, crc);
            }

            byte result = (byte)((crc & 0xFF) ^ (crc >> 8));
            return result;
        }

        private static IList<MessageFieldCrcData> ToMessageFieldCrcDatas(IEnumerable<MessageField> xMessageFields)
        {
            IList<MessageFieldCrcData> fieldCrcDatas = new List<MessageFieldCrcData>();
            Int32 definitionIndex = 0;
            foreach (Xml.MessageField messageField in xMessageFields)
            {
                MessageFieldCrcData fieldCrcData = new MessageFieldCrcData()
                {
                    DefinitionIndex = definitionIndex,
                    TypeLength = TypeHelper.GetTypeLength(messageField),
                    ArrayLength = TypeHelper.GetArraySize(messageField.Type),
                    Field = messageField
                };

                fieldCrcDatas.Add(fieldCrcData);
                definitionIndex++;
            }
            return fieldCrcDatas;
        }

        // Crc code copied/adapted from ardumega planner code / Mavlink C# generator (https://github.com/mavlink/mavlink)

        private const UInt16 X25InitCrc = 0xffff;

        public static UInt16 GetCrc(string s)
        {
            return GetCrc(s, X25InitCrc);
        }

        public static UInt16 GetCrc(string s, UInt16 crc)
        {
            // 28591 = ISO-8859-1 = latin1
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(s);

            foreach (byte b in bytes)
            {
                crc = GetCrc(b, crc);
            }

            return crc;
        }

        public static UInt16 GetCrc(byte b, UInt16 crc)
        {
            unchecked
            {
                byte ch = (byte)(b ^ (byte)(crc & 0x00ff));
                ch = (byte)(ch ^ (ch << 4));
                return (UInt16)((crc >> 8) ^ (ch << 8) ^ (ch << 3) ^ (ch >> 4));
            }
        }

        public static UInt16 GetCrc(byte[] buffer)
        {
            UInt16 crc = X25InitCrc;

            for (int i = 0; i < buffer.Length; ++i)
            {
                crc = GetCrc(buffer[i], crc);
            }

            return crc;
        }
    }
}
