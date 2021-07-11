using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Helpers
{
    class BinaryHelper
    {
        public static string ByteToHex(int byteValue)
        {
            if(byteValue >= 0 && byteValue <= 255)
            {
                return byteValue.ToString("X");
            }

            return String.Empty;
        }

        public static string ByteToHex(string byteValue)
        {
            if(byteValue.Length == 8)
            {
                return Convert.ToInt32("byteValue", 2).ToString("X");
            }

            return String.Empty;
        }

        public static int GetLowerNibbleValue(byte value)
        {
            return value & 0b00001111;
        }

        public static int GetHigherNibbleValue(byte value)
        {
            return value & 0b11110000;
        }

        public static int GetThreeNibbleValue(byte[] value)
        {
            return (GetLowerNibbleValue(value[0]) << 8) + value[1];
        }

        public static int GetLeastSignificantBitValue(byte value)
        {
            return value & 0b00000001;
        }

        public static int GetLeastSignificantBitValue(byte[] value)
        {
            return value[1] & 0b00000001;
        }

        public static int GetMostSignificantBitValue(byte value)
        {
            return value & 0b10000000;
        }

        public static int GetMostSignificantBitValue(byte[] value)
        {
            return value[0] & 0b10000000;
        }

        public static int HexToInt(string hexValue)
        {
            return Convert.ToInt32(hexValue, 16);
        }

        public static string IntToHex(int decValue)
        {
            return decValue.ToString("X");
        }
    }
}
