using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ArbitraryPixel.Applications.PC.PaletteManager.Interface
{
    public class ColorGrid : Control
    {
        private Bitmap m_bgImage = null;
        private Point m_target;

        public ColorGrid()
        {
            m_bgImage = new Bitmap((int)HSLColor.Scale, (int)HSLColor.Scale);

            double lum = HSLColor.Scale / 2;
            m_target = new Point((int)lum, (int)lum);
            for (int x = 0; x < m_bgImage.Width; x++)
            {
                for (int y = 0; y < m_bgImage.Height; y++)
                {
                    m_bgImage.SetPixel(x, y, (Color)(new HSLColor(x, m_bgImage.Height - y, lum)));
                }
            }

            this.Size = new Size(m_bgImage.Width, m_bgImage.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawImage(m_bgImage, this.ClientRectangle);
        }
    }
}
