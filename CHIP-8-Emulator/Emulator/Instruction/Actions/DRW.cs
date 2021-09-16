using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction.Actions
{
    class DRW : IExecutableInstruction
    {
        public void Execute(InstructionDTO instructionData, CPU cpu)
        {
            int yCoordinate = GetYCoordinate(instructionData, cpu);
            int rows = instructionData.N;
            cpu.VFRegister = 0;

            for (int row = 0; row < rows; row++)
            {
                int xCoordinate = GetXCoordinate(instructionData, cpu);
                byte dataOnRow = GetDataToDrawOnRow(cpu, row);

                for (int bit = 0; bit < 8; bit++)
                {
                    int currentBit = GetBitFromByte(ref dataOnRow);

                    cpu.VFRegister |= cpu.Display.SetPixel(xCoordinate, yCoordinate, currentBit);

                    xCoordinate--; //TODO. xCoor can go into negative numbers 
                    if (IndexAboveScreenSize(xCoordinate, yCoordinate))
                    {
                        break;
                    }
                }

                yCoordinate++;
                if (IndexAboveScreenSize(xCoordinate, yCoordinate))
                {
                    break;
                }
            }
        }

        private byte GetDataToDrawOnRow(CPU cpu, int row)
        {
            return cpu.Memory.GetByte(cpu.VIRegister + row);
        }

        private int GetXCoordinate(InstructionDTO instructionData, CPU cpu)
        {
            return cpu.Registers[instructionData.X] % Display.horizontalSize;
        }

        private int GetYCoordinate(InstructionDTO instructionData, CPU cpu)
        {
            return cpu.Registers[instructionData.Y] % Display.verticalSize;
        }

        private int GetBitFromByte(ref byte input)
        {
            int value = input % 2;
            input /= 2;
            return value;
        }

        private bool IndexAboveScreenSize(int x, int y)
        {
            return x >= Display.horizontalSize || y >= Display.verticalSize;
        }

    }
}
