using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class SKP : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            cpu.VFRegister = 0;

            var result = cpu.Registers[instructionData.X] + cpu.Registers[instructionData.Y];
            if (result > 255)
            {
                cpu.VFRegister = 1;
                result &= 0b11111111;
            }

            cpu.Registers[instructionData.X] = result;
        }
    }
}