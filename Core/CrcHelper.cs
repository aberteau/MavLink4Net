using System;
using System.Text;

namespace MavLink4Net.Core
{
    public class CrcHelper
    {
        // CRC code adapted from Mavlink C# generator (https://github.com/mavlink/mavlink)

        const UInt16 X25CrcSeed = 0xffff;

        public static UInt16 GetCrc(string s)
        {
            return GetCrc(s, X25CrcSeed);
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
    }
}
