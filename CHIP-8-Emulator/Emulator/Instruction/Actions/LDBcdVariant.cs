using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class LDBcdVariant : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            var value = cpu.Registers[instructionData.X];

            var onesDigit = value % 10;
            cpu.Memory.SetByte(cpu.VIRegister + 2, (byte)onesDigit);
            value /= 10;

            var tensDigit = value % 10;
            cpu.Memory.SetByte(cpu.VIRegister + 1, (byte)tensDigit);
            value /= 10;

            var hundretsDigit = value % 10;
            cpu.Memory.SetByte(cpu.VIRegister, (byte)hundretsDigit);
        }
    }
}
