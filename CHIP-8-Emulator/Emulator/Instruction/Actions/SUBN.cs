using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class SUBN : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            int registerXValue = cpu.Registers[instructionData.X];
            int registerYValue = cpu.Registers[instructionData.Y];

            cpu.VFRegister = registerYValue > registerXValue ? 1 : 0;

            cpu.Registers[instructionData.X] = registerYValue - registerXValue;
        }
    }
}
