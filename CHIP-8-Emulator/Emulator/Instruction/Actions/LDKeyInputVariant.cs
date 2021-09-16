using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class LDKeyInputVariant : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            if (cpu.CurrentlyPressedKeyboard != -1)
            {
                cpu.Registers[instructionData.X] = cpu.CurrentlyPressedKeyboard;
            }
            else
            {
                cpu.ProgramCounter -= 2; // makes the cpu stuck on this instruction until user input
            }
        }
    }
}
