using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class DoubleBufferedControl : Control
    {
        public DoubleBufferedControl()
        {
            this.DoubleBuffered = true;
        }
    }
}
