using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Helpers
{
    static class RandomGenerator
    {
        private static Random rnd = new Random();

        public static int GetRandomByte()
        {
            return rnd.Next(255);
        }
    }
}
