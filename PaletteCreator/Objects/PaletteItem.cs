using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class PaletteItem
    {
        public string Name { get; set; }
        public Color Color { get; set; }

        public PaletteItem(string name)
            : this(name, Constants.DEFAULT_PALETTE_ITEM_COLOR)
        {
        }

        public PaletteItem(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string RGBColor
        {
            get
            {
                return "rgb("
                    + this.Color.R.ToString() + ", "
                    + this.Color.G.ToString() + ", "
                    + this.Color.B.ToString()
                    + ")";
            }
        }

        public string HexColor
        {
            get
            {
                return "#"
                    + this.Color.R.ToString("X2")
                    + this.Color.G.ToString("X2")
                    + this.Color.B.ToString("X2");
            }
        }
    }
}
