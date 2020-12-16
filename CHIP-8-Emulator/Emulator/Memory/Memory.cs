using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator
{
    class Memory
    {        
        public const int programStartAdress = 511;
        public const int memorySize = 4096;

        private byte[] memory = new byte[memorySize];
        public bool InsertInstruction(byte[] instruction, int index)
        {
            if(index < programStartAdress || index > memorySize - 2)
            {
                return false;
            }

            if(instruction.Length != 2)
            {
                return false;
            }

            memory[index] = instruction[0];
            memory[index + 1] = instruction[1];

            return true;
        }
    }
}
