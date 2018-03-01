using System;
using System.Linq;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Data.Extensions;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.MessageDefinitions
{
    public class CrcHelper
    {
        public static byte GetExtraCrc(Message m)
        {
            UInt16 crc = GetCrc(m.Name + ' ');

            foreach (MessageField f in m.Fields.OrderForSerialization().ToList())
            {
                string rawDataType = MessageFieldTypeMapper.ToRawDataType(f.Type.DataType);
                crc = GetCrc(rawDataType + ' ', crc);
                crc = GetCrc(f.Name + ' ', crc);

                if (f.Type.ArrayLength > 1)
                    crc = GetCrc((byte)f.Type.ArrayLength, crc);
            }

            byte result = (byte)((crc & 0xFF) ^ (crc >> 8));
            return result;
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
