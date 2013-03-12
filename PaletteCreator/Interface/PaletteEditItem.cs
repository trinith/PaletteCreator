using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class PaletteEditItem : DoubleBufferedControl
    {
        #region Private Enums
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
        #endregion

        #region Public Properties
        public PaletteItem TargetPaletteItem { get; set; }
        #endregion

        #region Constructors
        public PaletteEditItem(PaletteItem item)
            : base()
        {
            if (item == null)
                throw new ArgumentNullException("item");

            m_customRenderers.Add(State.Normal, new CustomRenderer(DrawNormal));

            this.TargetPaletteItem = item;
        }
        #endregion

        #region Override Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            CustomRenderer renderer = m_customRenderers[State.Normal];

            if (m_customRenderers.ContainsKey(m_state))
                renderer = m_customRenderers[m_state];

            renderer.Draw(e.Graphics, this.ClientRectangle);
        }
        #endregion

        #region Render Methods
        public void DrawNormal(Graphics g, Rectangle bounds)
        {
            g.FillRectangle(new SolidBrush(this.TargetPaletteItem.Color), bounds);
        }
        #endregion
    }
}
