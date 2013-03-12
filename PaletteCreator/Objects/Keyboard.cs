using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class KeyboardState
    {
        private byte[] m_keys = new byte[255];

        public KeyboardState(byte[] keys)
        {
            m_keys = keys;
        }

        public bool IsKeyDown(Keys k)
        {
            return (m_keys[(int)k] == 129);
        }

        public bool IsKeyUp(Keys k)
        {
            return !IsKeyDown(k);
        }
    }

    public class Keyboard
    {
        public static KeyboardState GetState()
        {
            byte[] keys = new byte[255];
            Win32.GetKeyboardState(keys);

            return new KeyboardState(keys);
        }
    }
}
