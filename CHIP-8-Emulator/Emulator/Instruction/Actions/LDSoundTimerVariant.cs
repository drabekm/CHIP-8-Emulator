﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class LDSoundTimerVariant : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            cpu.STRegister = cpu.Registers[instructionData.X];
        }
    }
}