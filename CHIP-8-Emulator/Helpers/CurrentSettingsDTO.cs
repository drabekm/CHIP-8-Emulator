using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Helpers
{
    class CurrentSettingsDTO
    {
        public string ProgramName { get; set; }
        public bool IsCodeRunning { get; set; }

        public CurrentSettingsDTO()
        {

        }

        public CurrentSettingsDTO(string programName, bool isCoderunning)
        {
            this.ProgramName = programName;
            this.IsCodeRunning = isCoderunning;
        }
    }
}
