using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator.Instruction
{
    class InstructionDTO
    {
        public byte[] RawData {get; private set;}
        public string HexData { get; private set; }
        public InstructionType Type { get; private set; }
        public string Position { get; private set; }

        public InstructionDTO(byte[] rawData, string hexData, InstructionType type, string position)
        {
            RawData = rawData;
            HexData = hexData;
            Type = type;
            Position = position;
        }
    }
}
