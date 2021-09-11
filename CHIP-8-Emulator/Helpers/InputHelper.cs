using CHIP_8_Emulator.Emulator;
using System.Windows.Input;
using System.Collections.Generic;

namespace CHIP_8_Emulator.Helpers
{
    class InputHelper
    {
        private CPU cpu;
        private Dictionary<Key, int> inputValuesByKeyType = new Dictionary<Key, int>(); 

        public InputHelper(CPU cpu)
        {
            this.cpu = cpu;
            InitInputDictionary();
        }

        public void HandleKeyPress(object sender, KeyEventArgs e)
        {
            var pressedKey = e.Key;

            if (IsKeyUsedByChip8(pressedKey))
            {
                cpu.CurrentlyPressedKeyboard = inputValuesByKeyType[pressedKey];
            }
        }

        public void HendleKeyReleased(object sender, KeyEventArgs e)
        {
            var releasedKey = e.Key;

            if (IsKeyUsedByChip8(releasedKey) && IsCurrentlyReleasedKeyStoredInCpu(releasedKey))
            {
                cpu.CurrentlyPressedKeyboard = -1; // negative value means that nothing is pressed
            }
        }

        private bool IsKeyUsedByChip8(Key key)
        {
            return inputValuesByKeyType.ContainsKey(key);
        }

        private bool IsCurrentlyReleasedKeyStoredInCpu(Key key)
        {
            return cpu.CurrentlyPressedKeyboard == inputValuesByKeyType[key];
        }

        private void InitInputDictionary()
        {
            inputValuesByKeyType.Add(Key.D1, 0x1); // top row of keys
            inputValuesByKeyType.Add(Key.D2, 0x2);
            inputValuesByKeyType.Add(Key.D3, 0x3);
            inputValuesByKeyType.Add(Key.D4, 0xC);

            inputValuesByKeyType.Add(Key.Q, 0x4); // seccond row
            inputValuesByKeyType.Add(Key.W, 0x5);
            inputValuesByKeyType.Add(Key.E, 0x6);
            inputValuesByKeyType.Add(Key.R, 0xD);

            inputValuesByKeyType.Add(Key.A, 0x7);
            inputValuesByKeyType.Add(Key.S, 0x8);
            inputValuesByKeyType.Add(Key.D, 0x9);
            inputValuesByKeyType.Add(Key.F, 0xE);

            inputValuesByKeyType.Add(Key.Y, 0xA);
            inputValuesByKeyType.Add(Key.X, 0x0);
            inputValuesByKeyType.Add(Key.C, 0xB);
            inputValuesByKeyType.Add(Key.V, 0xF);
        }
    }
}
