using CHIP_8_Emulator.Emulator.Instruction;
using CHIP_8_Emulator.Emulator.Instruction.Actions;
using CHIP_8_Emulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator
{
    class CPU
    {
        public Memory Memory { get; set; }
        public int[] Registers { get; set; }
        public int ProgramCounter { get; set; }
        public Stack<int> CallStack { get; set; }

        private const int callStackSize = 16;

        public CPU()
        {
            Memory = new Memory();
            Registers = new int[16];
            CallStack = new Stack<int>(callStackSize);
            ProgramCounter = 0x200;
        }

        public void ExecuteSingleCycle()
        {
            var fetchedInstructionData = FetchInstruction();

            var decodedInstruction = DecodeInstruction(fetchedInstructionData);

            ExecuteInstruction(fetchedInstructionData, decodedInstruction);
        }

        private InstructionDTO FetchInstruction()
        {
            var instruction = Memory.GetInstruction(ProgramCounter);
            IncrementPC();
            return instruction;
        }

        private IExecutableInstruction DecodeInstruction(InstructionDTO instruction)
        {
            switch (instruction.HexData[0])
            {
                case '0':
                    if (instruction.HexData == "00E0") 
                    {
                        return new CLS();
                    }
                    else if (instruction.HexData == "00EE") 
                    {
                        return new RET();
                    }
                    break;
                case '1':
                    return new JP();
                case '2': 
                    return new CALL();
                case '3':
                    return new SE();
                case '7':
                    return new ADD();

            }

            return null;
        }

        private void ExecuteInstruction(InstructionDTO instructionData, IExecutableInstruction instruction)
        {
            instruction.Execute(instructionData, this);
        }

        public void Reset()
        {
            //this.Memory.Reset();
        }

        

        private void IncrementPC()
        {
            ProgramCounter += 2;
        }

    }
}
