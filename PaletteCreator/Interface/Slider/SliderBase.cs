using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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

        protected Dictionary<State, CustomRenderer> m_customRenderers = new Dictionary<State, CustomRenderer>();

        public double Maximum { get; set; }
        public double Minimum { get; set; }
        public double Value { get; set; }
      
        public SliderBase()
        {
            this.Minimum = 0;
            this.Maximum = 100;
            this.Value = 50;
            this.Padding = new Padding(5);
        }

        protected virtual RectangleF CalculateBounds()
        {
            return new RectangleF(
                this.ClientRectangle.X + this.Padding.Left,
                this.ClientRectangle.Y + this.Padding.Top,
                this.ClientRectangle.Width - this.Padding.Horizontal,
                this.ClientRectangle.Height - this.Padding.Vertical
            );
        }

        protected virtual void RenderBackground(Graphics g, RectangleF bounds)
        {
        }

        protected virtual void RenderGlyph(Graphics g, RectangleF bounds)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RectangleF bounds = this.CalculateBounds();
            RenderBackground(e.Graphics, bounds);
            RenderGlyph(e.Graphics, bounds);
        }
    }
}
