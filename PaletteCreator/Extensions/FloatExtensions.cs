using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public static partial class Extensions
    {
        public static float Clamp(this float val, float lower, float upper)
        {
            return ((val < lower) ? lower : (val > upper) ? upper : val);
        }
    }
}
