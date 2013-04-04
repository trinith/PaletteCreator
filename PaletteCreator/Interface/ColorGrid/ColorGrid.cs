using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class ColorGrid : DoubleBufferedControl
    {
        #region Private Members
        private const float TARGET_RADIUS = 4f;
        private Bitmap m_bgImage = null;
        private PointF m_target;
        private double m_brightness;
        #endregion

        #region Public Properties
        public bool ShowSelection { get; set; }

        public double Brightness
        {
            get { return m_brightness; }
            set { m_brightness = value; this.UpdateFromColorChange(); }
        }

        public double Saturation
        {
            get { return (double)(m_bgImage.Height - m_target.Y); }
            set { m_target.Y = (int)(m_bgImage.Height - value); this.UpdateFromColorChange(); }
        }

        public double Hue
        {
            get { return m_target.X; }
            set { m_target.X = (float)value; this.UpdateFromColorChange(); }
        }

        public Color CurrentColor
        {
            get { return (Color)(new HSLColor(this.Hue, this.Saturation, this.Brightness)); }
            set
            {
                HSLColor color = (HSLColor)value;
                m_target.X = (float)color.Hue;
                m_target.Y = (float)(m_bgImage.Height - color.Saturation);
                m_brightness = color.Luminosity;

                this.UpdateFromColorChange();
            }
        }
        #endregion

        #region Events
        public event EventHandler ColorChanged;
        #endregion

        #region Constructors
        public ColorGrid()
        {
            m_bgImage = new Bitmap((int)HSLColor.Scale, (int)HSLColor.Scale);

            m_brightness = HSLColor.Scale / 2;
            m_target = new PointF((float)m_brightness, (float)m_brightness);
            for (int x = 0; x < m_bgImage.Width; x++)
            {
                for (int y = 0; y < m_bgImage.Height; y++)
                {
                    m_bgImage.SetPixel(x, y, (Color)(new HSLColor(x, m_bgImage.Height - y, this.Brightness)));
                }
            }

            this.Size = new Size(m_bgImage.Width, m_bgImage.Height);
            this.ShowSelection = true;
        }
        #endregion

        #region Override Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawImage(m_bgImage, this.ClientRectangle);

            if (this.ShowSelection)
            {
                PointF scale = new PointF((float)this.ClientRectangle.Width / (float)m_bgImage.Width, (float)this.ClientRectangle.Height / (float)m_bgImage.Height);
                Color currentColor = m_bgImage.GetPixel((int)m_target.X, (int)m_target.Y);
                Pen targetPen = Pens.White;
                
                if (currentColor.GetLuminance() > 0.5)
                    targetPen = Pens.Black;

                e.Graphics.DrawEllipse(
                    targetPen,
                    (scale.X * m_target.X) - TARGET_RADIUS,
                    (scale.Y * m_target.Y) - TARGET_RADIUS,
                    TARGET_RADIUS * 2,
                    TARGET_RADIUS * 2
                );
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            m_target = GetScaledPoint(e.Location);
            UpdateFromColorChange();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                m_target = GetScaledPoint(e.Location);
                UpdateFromColorChange();
            }
        }
        #endregion

        #region Protected Methods
        protected void OnColorChanged(EventArgs e)
        {
            if (this.ColorChanged != null)
                this.ColorChanged(this, e);
        }
        #endregion

        #region Private Methods
        private void UpdateFromColorChange()
        {
            this.Invalidate();
            OnColorChanged(new EventArgs());
        }

        private PointF GetScaledPoint(PointF originalPoint)
        {
            PointF scaledPoint = originalPoint;
            PointF scale = new PointF((float)this.ClientRectangle.Width / (float)m_bgImage.Width, (float)this.ClientRectangle.Height / (float)m_bgImage.Height);

            scaledPoint.X /= scale.X;
            scaledPoint.Y /= scale.Y;

            scaledPoint.X = scaledPoint.X.Clamp(0, m_bgImage.Width - 1);
            scaledPoint.Y = scaledPoint.Y.Clamp(0, m_bgImage.Height- 1);

            return scaledPoint;
        }
        #endregion
    }
}
