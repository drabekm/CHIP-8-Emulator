using CHIP_8_Emulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class SHL : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            int registerXValue = cpu.Registers[instructionData.X];

            cpu.VFRegister = BinaryHelper.GetMostSignificantBitValue((byte)registerXValue);

            cpu.Registers[instructionData.X] *= 2;
        }
    }
}
