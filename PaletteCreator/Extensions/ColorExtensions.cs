using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public static partial class Extentions
    {
        public static double GetLuminance(this Color c)
        {
            double nR = (double)c.R / 255d;
            double nG = (double)c.G / 255d;
            double nB = (double)c.B / 255d;

            double l = 
                0.2126 * nR +
                0.7152 * nG +
                0.0722 * nB;

            return l;
        }
    }
}
