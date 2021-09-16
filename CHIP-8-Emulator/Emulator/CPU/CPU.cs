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
        #region Components
        public Memory Memory { get; set; }
        public Display Display { get; set; }
        #endregion

        #region Registers
        public int[] Registers { get; set; } // general registers
        public int VIRegister { get; set; } // index register
        public int VFRegister { get; set; } // flag register
        public int DTRegister { get; set; } // delay timer register
        public int STRegister { get; set; } // sound timer register
        #endregion

        public int ProgramCounter { get; set; }
        public Stack<int> CallStack { get; set; }
        public int CurrentlyPressedKeyboard { get; set; } // negative value means that no key is pressed

        private const int callStackSize = 16;
        private const int registerCount = 16;
        private const int programStartAddress = 0x200;

        public CPU(Canvas displayCanvas)
        {            
            Display = new Display(displayCanvas);
            Memory = new Memory();

            InitializeRegisters();
        }

        public void ResetEverything()
        {
            InitializeRegisters();
            Memory.CleanMemory();
            Display.ResetDisplay();
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
                        case '3':
                            return new XOR();
                        case '4':
                            return new ADDRegisterVariant();
                        case '5':
                            return new SUB();
                        case '6':
                            return new SHR();
                        case '7':
                            return new SUBN();
                        case 'E':
                            return new SHL();
                    }
                    break;
                case '9':
                    return new SNE();
                case 'A':
                    return new LDIndexVariant();
                case 'B':
                    return new JPRegisterVariant();
                case 'C':
                    return new RND();
                case 'D':
                    return new DRW();
                case 'E':
                    switch (instruction.KK)
                    {
                        case 0x9E:
                            return new SKP();
                        case 0xA1:
                            return new SKNP();
                    }
                    break;
                case 'F':
                    switch (instruction.KK)
                    {
                        case 0x07:
                            return new LDDelayTimerVariantDTtoVX();
                        case 0x0A:
                            return new LDKeyInputVariant();
                        case 0x18:
                            return new LDSoundTimerVariant();
                        case 0x1E:
                            return new ADDIRegisterVariant();
                    }
                    break;
            }

            return new BlankInstruction(); //Don't want to use 'default' in switch, because it has nested switch statements
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
           /* if (instructionData == null || instructionData.RawData.All(x => x == 0))
            {
                throw new Exception("Instruction data cannot be null or empty");
            }
            if (instruction == null)
            {
               // throw new Exception("Instruction implementation cannot be null");
            }*/
        }

        private void InitializeRegisters()
        {
            Registers = new int[registerCount];
            CallStack = new Stack<int>(callStackSize);
            ProgramCounter = programStartAddress;

            VIRegister = 0;
            VFRegister = 0;
            DTRegister = 0;
            STRegister = 0;
        }


    }
}
