using CHIP_8_Emulator.Emulator.Instruction;
using CHIP_8_Emulator.Emulator.Instruction.Actions;
using CHIP_8_Emulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CHIP_8_Emulator.Emulator
{
    class CPU
    {
        public Memory Memory { get; set; }
        public Display Display { get; set; }

        public int[] Registers { get; set; }
        public int VIRegister { get; set; }
        public int VFRegister { get; set; }

        public int ProgramCounter { get; set; }
        public Stack<int> CallStack { get; set; }

        private const int callStackSize = 16;
        private const int registerCount = 16;

        public CPU(Canvas displayCanvas)
        {
            Memory = new Memory();
            Display = new Display(displayCanvas);

            Registers = new int[registerCount];
            CallStack = new Stack<int>(callStackSize);
            ProgramCounter = 0x200;

            VIRegister = 0;
            VFRegister = 0;
        }

        public void Reset()
        {
            Memory = new Memory();
            CallStack.Clear();
            Registers = new int[registerCount];
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

        private void IncrementPC()
        {
            ProgramCounter += 2;
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
                case '4':
                    return new SNE();
                case '5':
                    return new SERegisterVariant();
                case '6':
                    return new LD();
                case '7':
                    return new ADD();
                case '8':
                    switch(instruction.HexData[3])
                    {
                        case '0':
                            return new LDRegisterVariant();
                        case '1':
                            return new OR();
                        case '2':
                            return new AND();
                    }
                    break;
                case 'A':
                    return new LDIndexVariant();
                case 'D':
                    return new DRW();
            }

            return null;
        }

        private void ExecuteInstruction(InstructionDTO instructionData, IExecutableInstruction instruction)
        {
            ValidateInstruction(instructionData, instruction);
            instruction.Execute(instructionData, this);

            RedrawDisplayIfNeeded(instruction);
        }

        private void RedrawDisplayIfNeeded(IExecutableInstruction instruction)
        {
            if (instruction is DRW)
            {
                Display.RedrawDisplay();
            }
        }

        private void ValidateInstruction(InstructionDTO instructionData, IExecutableInstruction instruction)
        {
            if (instructionData == null || instructionData.RawData.All(x => x == 0))
            {
                throw new Exception("Instruction data cannot be null or empty");
            }
            if (instruction == null)
            {
                throw new Exception("Instruction implementation cannot be null");
            }
        }
                
    }
}
