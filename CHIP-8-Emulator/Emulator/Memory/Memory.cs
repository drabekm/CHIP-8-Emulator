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
        
        public Memory()
        {
            InsertFont();
        }

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

        public byte GetByte(int address)
        {
            return memory[address];
        }

        public void SetByte(int address, byte value)
        {
            memory[address] = value;
        }

        public void CleanMemory()
        {
            memory = new byte[memorySize];
            lastInsertedInstructionAdress = programStartAdress;
            InsertFont();
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

        private void InsertFont()
        {
            //0
            InserFontByte(0x0, 0xF0);
            InserFontByte(0x2, 0x90);
            InserFontByte(0x4, 0x90);
            InserFontByte(0x6, 0x90);
            InserFontByte(0x8, 0xF0);

            //1
            InserFontByte(0xA, 0x20);
            InserFontByte(0xC, 0x60);
            InserFontByte(0xE, 0x20);
            InserFontByte(0x10, 0x20);
            InserFontByte(0x12, 0x70);

            //2
            InserFontByte(0x14, 0xF0);
            InserFontByte(0x16, 0x10);
            InserFontByte(0x18, 0xF0);
            InserFontByte(0x1A, 0x80);
            InserFontByte(0x1C, 0xF0);

            //3
            InserFontByte(0x1E, 0xF0);
            InserFontByte(0x20, 0x10);
            InserFontByte(0x22, 0xF0);
            InserFontByte(0x24, 0x10);
            InserFontByte(0x26, 0xF0);

            //4
            InserFontByte(0x28, 0x90);
            InserFontByte(0x2A, 0x90);
            InserFontByte(0x2C, 0xF0);
            InserFontByte(0x2E, 0x10);
            InserFontByte(0x30, 0x10);

            //5
            InserFontByte(0x32, 0xF0);
            InserFontByte(0x34, 0x80);
            InserFontByte(0x36, 0xF0);
            InserFontByte(0x38, 0x10);
            InserFontByte(0x3A, 0xF0);

            //6
            InserFontByte(0x3C, 0xF0);
            InserFontByte(0x3E, 0x80);
            InserFontByte(0x40, 0xF0);
            InserFontByte(0x42, 0x90);
            InserFontByte(0x44, 0xF0);

            //7
            InserFontByte(0x46, 0xF0);
            InserFontByte(0x48, 0x10);
            InserFontByte(0x4A, 0x20);
            InserFontByte(0x4C, 0x40);
            InserFontByte(0x4E, 0x40);

            //8
            InserFontByte(0x50, 0xF0);
            InserFontByte(0x52, 0x90);
            InserFontByte(0x54, 0xF0);
            InserFontByte(0x56, 0x90);
            InserFontByte(0x58, 0xF0);

            //9
            InserFontByte(0x5A, 0xF0);
            InserFontByte(0x5C, 0x90);
            InserFontByte(0x5E, 0xF0);
            InserFontByte(0x60, 0x10);
            InserFontByte(0x62, 0xF0);

            //A
            InserFontByte(0x64, 0xF0);
            InserFontByte(0x66, 0x90);
            InserFontByte(0x68, 0xF0);
            InserFontByte(0x6A, 0x90);
            InserFontByte(0x6C, 0x90);

            //B
            InserFontByte(0x6E, 0xE0);
            InserFontByte(0x70, 0x90);
            InserFontByte(0x72, 0xE0);
            InserFontByte(0x74, 0x90);
            InserFontByte(0x76, 0xE0);

            //C
            InserFontByte(0x78, 0xF0);
            InserFontByte(0x7A, 0x80);
            InserFontByte(0x7C, 0x80);
            InserFontByte(0x7E, 0x80);
            InserFontByte(0x80, 0xF0);

            //D
            InserFontByte(0x82, 0xE0);
            InserFontByte(0x84, 0x90);
            InserFontByte(0x86, 0x90);
            InserFontByte(0x88, 0x90);
            InserFontByte(0x8A, 0xE0);

            //E
            InserFontByte(0x8C, 0xF0);
            InserFontByte(0x8E, 0x80);
            InserFontByte(0x90, 0xF0);
            InserFontByte(0x92, 0x80);
            InserFontByte(0x94, 0xF0);

            //F
            InserFontByte(0x96, 0xF0);
            InserFontByte(0x98, 0x80);
            InserFontByte(0x9A, 0xF0);
            InserFontByte(0x9C, 0x80);
            InserFontByte(0x9D, 0x80);
        }

        private void InserFontByte(int address, int value)
        {
            memory[address] = (byte)value;
        }
    }
}
