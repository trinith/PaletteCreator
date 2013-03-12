using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class PaletteEditItem : DoubleBufferedControl
    {
        #region Private Enums
        [Flags]
        private enum State
        {
            Normal,
            Selected,
            Hot
        }
        #endregion

        #region Private Members
        private Dictionary<State, CustomRenderer> m_customRenderers = new Dictionary<State, CustomRenderer>();
        private State m_state = State.Normal;
        private bool m_isSelected = false;
        
        private Point? m_clickLoc = null;
        #endregion

        #region Public Properties
        public PaletteItem TargetPaletteItem { get; set; }
        public bool IsMoving { get; private set; }
        public bool IsInteractive { get; set; }
        public bool IsMovable { get; set; }

        public bool IsSelected
        {
            get { return m_isSelected; }
            set
            {
                if (value != m_isSelected)
                {
                    if (value == true)
                        m_state |= State.Selected;
                    else
                        m_state &= ~State.Selected;

                    m_isSelected = value;
                }
            }
        }
        #endregion

        #region Constructors
        public PaletteEditItem(PaletteItem item)
            : base()
        {
            if (item == null)
                throw new ArgumentNullException("item");

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            this.Location = new Point(0, 0);
            this.Size = new Size(100, 100);

            this.IsInteractive = true;
            this.IsMovable = true;

            m_customRenderers.Add(State.Normal, new CustomRenderer(DrawNormal));
            m_customRenderers.Add(State.Normal | State.Hot, new CustomRenderer(DrawNormalHot));
            m_customRenderers.Add(State.Selected, new CustomRenderer(DrawSelected));
            m_customRenderers.Add(State.Selected | State.Hot, new CustomRenderer(DrawSelectedHot));

            this.TargetPaletteItem = item;
        }
        #endregion

        #region Override Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;

            if (this.Parent != null)
            {
                int index = this.Parent.Controls.GetChildIndex(this);
                for (int i = this.Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = this.Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(this.Bounds) && c.Visible)
                    {
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - this.Left, c.Top - this.Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(this.Left - c.Left, this.Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // TODO: Transparency leaves artifacts behind... worry about this later.

            base.OnPaint(e);

            CustomRenderer renderer = m_customRenderers[State.Normal];

            if (m_customRenderers.ContainsKey(m_state))
                renderer = m_customRenderers[m_state];

            renderer.Draw(e.Graphics, this.ClientRectangle);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.IsInteractive)
            {
                m_state = m_state | State.Hot;
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.IsInteractive)
            {
                m_state = m_state & (~State.Hot);
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            m_clickLoc = null;
            this.IsMoving = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.IsInteractive)
                this.BringToFront();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!this.IsInteractive)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (m_clickLoc == null)
                {
                    m_clickLoc = new Point(e.X, e.Y);
                }
            }

            if (m_clickLoc != null)
            {
                // If we have a click location and the current point isn't that, we've moved.
                if (e.Location != m_clickLoc)
                {
                    this.IsMoving = true;
                    this.Focus();
                }

                if (this.IsMovable)
                {
                    this.Location = new Point(
                        this.Location.X + e.X - m_clickLoc.Value.X,
                        this.Location.Y + e.Y - m_clickLoc.Value.Y
                    );

                    this.Invalidate();
                }
            }
        }

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);

            this.IsSelected = true;
        }
        #endregion

        #region Render Methods
        private void DrawSelectionIndicator(Graphics g, Rectangle bounds, Color color)
        {
            DrawCorner(g, bounds, color);
            Matrix originalTransform = g.Transform;

            g.TranslateTransform(bounds.Width, 0);
            g.RotateTransform(90);
            DrawCorner(g, bounds, color);
            g.Transform = originalTransform;

            g.TranslateTransform(0, bounds.Height);
            g.RotateTransform(270);
            DrawCorner(g, bounds, color);
            g.Transform = originalTransform;

            g.TranslateTransform(bounds.Width, bounds.Height);
            g.RotateTransform(180);
            DrawCorner(g, bounds, color);
            g.Transform = originalTransform;
        }

        private void DrawCorner(Graphics g, Rectangle bounds, Color color)
        {
            g.FillPolygon(
                new SolidBrush(color),
                new PointF[] {
                    new PointF(bounds.Left, bounds.Top),
                    new PointF(bounds.Left + (bounds.Width * Constants.EDIT_INDICATOR_SIZE), bounds.Top),
                    new PointF(bounds.Left + (bounds.Width * Constants.EDIT_INDICATOR_SIZE), bounds.Top + (bounds.Height * Constants.EDIT_INDICATOR_THICKNESS)),
                    new PointF(bounds.Left + (bounds.Width * Constants.EDIT_INDICATOR_THICKNESS), bounds.Top + (bounds.Height * Constants.EDIT_INDICATOR_THICKNESS)),
                    new PointF(bounds.Left + (bounds.Width * Constants.EDIT_INDICATOR_THICKNESS), bounds.Top + (bounds.Height * Constants.EDIT_INDICATOR_SIZE)),
                    new PointF(bounds.Left, bounds.Top + bounds.Top + (bounds.Height * Constants.EDIT_INDICATOR_SIZE)),
                }
            );
        }

        private void DrawSwatch(Graphics g, Rectangle bounds)
        {
            RectangleF swatchBounds = new RectangleF(
                bounds.Left + (bounds.Width * (Constants.EDIT_INDICATOR_THICKNESS / 2f)),
                bounds.Top + (bounds.Height * (Constants.EDIT_INDICATOR_THICKNESS / 2f)),
                bounds.Width - (bounds.Width * Constants.EDIT_INDICATOR_THICKNESS),
                bounds.Height - (bounds.Height * Constants.EDIT_INDICATOR_THICKNESS)
            );
            g.FillRectangle(new SolidBrush(this.TargetPaletteItem.Color), swatchBounds);
        }

        private void DrawNormal(Graphics g, Rectangle bounds)
        {
            DrawSwatch(g, bounds);
        }

        private void DrawNormalHot(Graphics g, Rectangle bounds)
        {
            DrawSwatch(g, bounds);
            DrawSelectionIndicator(g, bounds, Color.Gray);
        }

        private void DrawSelected(Graphics g, Rectangle bounds)
        {
            DrawSwatch(g, bounds);
            DrawSelectionIndicator(g, bounds, Color.DarkGray);
        }

        private void DrawSelectedHot(Graphics g, Rectangle bounds)
        {
            DrawSwatch(g, bounds);
            DrawSelectionIndicator(g, bounds, Color.LightGray);
        }
        #endregion
    }
}
