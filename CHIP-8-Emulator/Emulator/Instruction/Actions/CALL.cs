using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class CALL : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            cpu.CallStack.Push(cpu.ProgramCounter);
            cpu.ProgramCounter = instructionData.NNN;
        }
    }
}
