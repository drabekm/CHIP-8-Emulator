using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Helpers
{
    class BinaryConvertor
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
