using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIP_8_Emulator.Emulator
{
    class FileHandler
    {
        public List<byte> FileData { get; private set; }

        public FileHandler()
        {

        }

        /// <summary>
        /// Loads .ch8 file into byte array.
        /// </summary>
        /// <returns>True/false on succes</returns>
        public bool LoadFile(string path, Memory memory)
        {
            bool readingSuccesfull = false;
            memory.CleanMemory();
            try
            {
                if (File.Exists(path))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        byte[] instruction = new byte[2];

                        while ((reader.BaseStream.Length - reader.BaseStream.Position) >= 2)
                        {
                            instruction = reader.ReadBytes(2);
                            memory.InsertInstruction(instruction);
                        }
                    }
                    readingSuccesfull = true;
                }
            }
            catch
            {
                readingSuccesfull = false;
            }

            return readingSuccesfull;
        }
    }
}
