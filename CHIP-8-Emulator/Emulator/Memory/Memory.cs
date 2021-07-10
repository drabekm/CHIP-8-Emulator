using CHIP_8_Emulator.Emulator.Instruction;
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
        
        
        //Stack<int> callStack = new Stack<int>(12);

        public const int programStartAdress = 0x200;
        public const int memorySize = 4096;
        private int lastInstructionAdress = programStartAdress;

        private byte[] memory = new byte[memorySize];
        public void InsertInstruction(byte[] instruction)
        {            
            if(instruction.Length != 2)
            {
                throw new Exception("Instruction is not two bytes long");
            }

            memory[lastInstructionAdress] = instruction[0];
            memory[lastInstructionAdress + 1] = instruction[1];
            lastInstructionAdress += 2;
        }

        public InstructionDTO GetInstruction(int address)
        {
            byte[] rawInstruction = new byte[2];
            rawInstruction[0] = memory[address];
            rawInstruction[1] = memory[address + 1];
            return new InstructionDTO(rawInstruction, address);
        }

       /* public InstructionDTO[] GetNNextInstructions(int n)
        {
            var instructions = new byte[n * 2];
            for(int i = 0; i < n; i++)
            {
                instructions[0]
            }
        }*/

       /* public void Reset()
        {
            callStack.Clear();

            for(int i = 0; i < registers.Count(); i++)
            {
                registers[i] = 0;
            }
        }*/
    }
}
