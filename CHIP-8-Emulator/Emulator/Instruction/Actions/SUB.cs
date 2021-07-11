﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class SUB : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            int registerX = cpu.Registers[instructionData.X];
            int registerY = cpu.Registers[instructionData.Y];

            cpu.VFRegister = registerX > registerY ? 1 : 0;

            cpu.Registers[instructionData.X] = registerX - registerY;
            
        }
    }
}
