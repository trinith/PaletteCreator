using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class VerticalSlider : SliderBase
    {
        protected override void RenderBackground(Graphics g, RectangleF bounds)
        {
            g.DrawLine(
                Pens.DarkGray,
                bounds.Left + bounds.Width / 2f - 1,
                bounds.Top + this.Padding.Top,
                bounds.Left + bounds.Width / 2f - 1,
                bounds.Bottom - this.Padding.Bottom
            );

            g.DrawLine(
                Pens.Gray,
                bounds.Left + bounds.Width / 2f,
                bounds.Top + this.Padding.Top,
                bounds.Left + bounds.Width / 2f,
                bounds.Bottom - this.Padding.Bottom
            );

            g.DrawLine(
                Pens.White,
                bounds.Left + bounds.Width / 2 + 1f,
                bounds.Top + this.Padding.Top,
                bounds.Left + bounds.Width / 2f + 1,
                bounds.Bottom - this.Padding.Bottom
            );
        }

        protected override void RenderGlyph(Graphics g, RectangleF bounds)
        {
            
        }
    }
}
