using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class Win32
    {
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);
    }
}
