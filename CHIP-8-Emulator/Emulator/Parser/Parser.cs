using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHIP_8_Emulator.Emulator.Instruction;

namespace CHIP_8_Emulator.Emulator
{
    class Parser
    {
        

        public List<InstructionDTO> Instructions = new List<InstructionDTO>();

        public Parser()
        {

        }

        public bool Parse(List<byte> input)
        {
            bool parseSuccesfull = false;

            const int take = 2;
            int skip = 0;
            if(Validate(input))
            {
                while(input.Count() != skip)
                {
                    var currentPair = input.Skip(skip).Take(take);
                    skip += take;


                }
            }

            return parseSuccesfull;
        }

        /// <summary>
        /// Instructions are 2 bytes big. If input count is not even it's not loaded corectly
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool Validate(List<byte> input)
        {
            return input.Count % 2 == 0;
        }

    }
}
