using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class SliderBase : DoubleBufferedControl
    {
        [Flags]
        protected enum State
        {
            Normal,
            GlyphHot,
            GlyphActive
        }

        

        public double Maximum { get; set; }
        public double Minimum { get; set; }
        public double Value { get; set; }

        public SliderBase()
        {
            this.Minimum = 0;
            this.Maximum = 100;
            this.Value = 50;
        }
    }
}
