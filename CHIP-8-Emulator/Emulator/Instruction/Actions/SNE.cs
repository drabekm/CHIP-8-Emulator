using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class SNE : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            if (cpu.Registers[instructionData.X] != instructionData.KK)
            {
                cpu.ProgramCounter += 2;
            }
        }
    }
}
