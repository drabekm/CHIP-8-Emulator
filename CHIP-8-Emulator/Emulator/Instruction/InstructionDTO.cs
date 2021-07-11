using CHIP_8_Emulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction
{
    class InstructionDTO
    {
        /// <summary>
        /// Two byte array representing the instruction
        /// </summary>
        public byte[] RawData {get; private set;}

        /// <summary>
        /// Hex code of instruction
        /// </summary>
        public string HexData { get; private set; }

        /// <summary>
        /// Position of instruction in memory
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// A 12-bit value, the lowest 12 bits of the instruction
        /// </summary>
        public int NNN { get; private set; }

        /// <summary>
        /// A 4-bit value, the lowest 4 bits of the instruction
        /// </summary>
        public int N { get; private set; }

        /// <summary>
        /// A 4-bit value, the lower 4 bits of the high byte of the instruction
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// A 4-bit value, the upper 4 bits of the low byte of the instruction
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// An 8-bit value, the lowest 8 bits of the instruction
        /// </summary>
        public int KK { get; private set; }

        public InstructionDTO(byte[] rawData, int position)
        {
            RawData = rawData;            
            Position = position;
            HexData = BitConverter.ToString(rawData).Replace("-", "");

            NNN = BinaryHelper.GetThreeNibbleValue(rawData);
            N = BinaryHelper.GetLowerNibbleValue(rawData[1]);
            X = BinaryHelper.GetLowerNibbleValue(rawData[0]);
            Y = BinaryHelper.GetHigherNibbleValue(rawData[1]) >> 4;
            KK = rawData[1];
        }

        
    }
}
