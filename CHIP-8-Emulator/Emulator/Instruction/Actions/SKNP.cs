using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class SKNP : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            var registerValue = cpu.Registers[instructionData.X];
            var currentKey = cpu.CurrentlyPressedKeyboard;
            if (registerValue != currentKey)
            {
                cpu.ProgramCounter += 2;
            }
        }
    }
}