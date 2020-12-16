using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction
{
    public enum InstructionType
    {
        Call,
        Display,
        Flow,
        Cond,
        Assign,
        BitOp,
        Math,
        Mem,
        Rand,
        KeyOp,
        Timer,
        Sound,
        Bcd
    }
}
