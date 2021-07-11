using CHIP_8_Emulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class RND : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            cpu.Registers[instructionData.X] = instructionData.KK + RandomGenerator.GetRandomByte();
        }
    }
}
