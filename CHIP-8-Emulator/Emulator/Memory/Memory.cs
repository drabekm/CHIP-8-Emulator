using CHIP_8_Emulator.Emulator.Instruction;
using System;
using System.Linq;

namespace CHIP_8_Emulator.Emulator
{
    class Memory
    {
        private const int programStartAdress = 0x200;
        private const int memorySize = 4096;

        private byte[] memory = new byte[memorySize];
        private int lastInsertedInstructionAdress = programStartAdress;
        
        public void InsertInstruction(byte[] instruction)
        {
            ValidateInsertedInstruction(instruction);

            memory[lastInsertedInstructionAdress] = instruction[0];
            memory[lastInsertedInstructionAdress + 1] = instruction[1];
            lastInsertedInstructionAdress += 2;
        }

        public InstructionDTO GetInstruction(int address)
        {
            byte[] rawInstruction = new byte[2];
            rawInstruction[0] = memory[address];
            rawInstruction[1] = memory[address + 1];
            return new InstructionDTO(rawInstruction, address);
        }

        private void ValidateInsertedInstruction(byte[] instruction)
        {
            if (instruction.Length != 2)
            {
                throw new Exception("Instruction is not two bytes long");
            }
            else if (instruction.All(x => x == 0))
            {
                throw new Exception("Instruction cannot be empty");
            }
        }
    }
}
