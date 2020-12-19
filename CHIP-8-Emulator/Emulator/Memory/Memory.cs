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
        int programCounter = 0x200;
        int[] registers = new int[16];
        Stack<int> callStack = new Stack<int>(12);

        public const int programStartAdress = 511;
        public const int memorySize = 4096;        

        private byte[] memory = new byte[memorySize];
        public void InsertInstruction(byte[] instruction, int index)
        {
            if(index < programStartAdress || index > memorySize - 2)
            {
                throw new Exception("Storing instruction in a non instruction space");
            }

            if(instruction.Length != 2)
            {
                throw new Exception("Instruction is not two bytes long");
            }

            memory[index] = instruction[0];
            memory[index + 1] = instruction[1];
        }

        public void IncrementProgramCounter()
        {
            programCounter++;
        }

        public void ChangeProgramCounter(int value)
        {
            if (value < 0)
            {
                throw new Exception("PC cannot be negative value");
            }

            programCounter = value;
        }

        public void Reset()
        {
            programCounter = 0x200;
            callStack.Clear();

            for(int i = 0; i < registers.Count(); i++)
            {
                registers[i] = 0;
            }
        }
    }
}
