using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MavLink4Net.Core;
using MavLink4Net.MessageDefinitions.Mappers;
using MavLink4Net.MessageDefinitions.Xml;

namespace MavLink4Net.MessageDefinitions
{
    public class MessageCrcHelper
    {
        public static byte GetExtraCrc(string xMessageName, IEnumerable<MessageField> xMessageFields)
        {
            UInt16 crc = CrcHelper.GetCrc(xMessageName + ' ');

            IList<MessageFieldCrcData> fieldCrcDatas = ToMessageFieldCrcDatas(xMessageFields);

            foreach (MessageFieldCrcData fieldCrcData in fieldCrcDatas.OrderByDescending(t => t.TypeLength).ThenBy(t => t.DefinitionIndex).ToList())
            {
                String translatedRawType = TypeHelper.TranslatePrimitiveRawType(fieldCrcData.Field.Type);
                string rawDataType = TypeHelper.ToRawDataType(translatedRawType);
                crc = CrcHelper.GetCrc(rawDataType + ' ', crc);
                crc = CrcHelper.GetCrc(fieldCrcData.Field.Name + ' ', crc);

                if (fieldCrcData.ArrayLength > 1)
                    crc = CrcHelper.GetCrc((byte)fieldCrcData.ArrayLength, crc);
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
    }
}
