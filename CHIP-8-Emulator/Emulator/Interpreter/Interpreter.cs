using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator
{
    class Interpreter
    {
        public Memory Memory { get; set; }

        public Interpreter()
        {
            Memory = new Memory();
        }
    }
}
