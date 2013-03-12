using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public partial class PaletteEditPanel : Panel
    {
        #region Private Members
        private Palette m_targetPalette = null;
        private Dictionary<PaletteItem, PaletteEditItem> m_editItems = new Dictionary<PaletteItem, PaletteEditItem>();
        private List<PaletteEditItem> m_selectedItems = new List<PaletteEditItem>();
        #endregion

        #region Public Properties
        public Palette TargetPalette
        {
            get { return m_targetPalette; }
            set
            {
                TearDownEventsAndItems();

                m_targetPalette = value;
                
                SetupEventsAndItems();
                Invalidate();
            }
        }
        #endregion

        #region Constructors
        public PaletteEditPanel()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }
        #endregion

        #region Private Methods
        private Point GetInsertionPoint()
        {
            Point p = new Point(8, 8);

            if (m_editItems.Count > 0)
            {
                PaletteItem keyItem = m_editItems.Keys.Select(x => x).ToArray()[m_editItems.Count - 1];
                PaletteEditItem pei = m_editItems[keyItem];
                p = new Point(
                    pei.Location.X + pei.Size.Width / 2,
                    pei.Location.Y + pei.Size.Height / 2
                );
            }

            return p;
        }

        private void CreatePaletteEditItem(PaletteItem item)
        {
            PaletteEditItem editItem = new PaletteEditItem(item);
            editItem.Location = GetInsertionPoint();
            editItem.MouseClick += new MouseEventHandler(editItem_MouseClick);

            m_editItems.Add(item, editItem);
            this.Controls.Add(editItem);
        }

        private void SetupEventsAndItems()
        {
            if (m_targetPalette != null)
            {
                foreach (PaletteItem p in m_targetPalette.PaletteItems)
                {
                    CreatePaletteEditItem(p);
                }

                m_targetPalette.PaletteItems.ItemAdded += new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemAdded);
                m_targetPalette.PaletteItems.ItemRemoved += new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemRemoved);
                m_targetPalette.PaletteItems.ItemsCleared += new EventHandler(PaletteItems_ItemsCleared);
            }
        }

        private void TearDownEventsAndItems()
        {
            this.Controls.Clear();
            m_editItems.Clear();

            if (m_targetPalette != null)
            {
                m_targetPalette.PaletteItems.ItemAdded -= new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemAdded);
                m_targetPalette.PaletteItems.ItemRemoved -= new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemRemoved);
                m_targetPalette.PaletteItems.ItemsCleared -= new EventHandler(PaletteItems_ItemsCleared);
            }
        }

        private void DeselectItems()
        {
            foreach (PaletteEditItem p in m_selectedItems)
            {
                p.IsSelected = false;
                p.Invalidate();
            }

            m_selectedItems.Clear();
        }
        #endregion

        #region Public Methods
        public void CreateNewSwatch()
        {
            m_targetPalette.PaletteItems.Add(new PaletteItem("New Swatch"));
        }
        #endregion

        #region Event Handlers
        void PaletteItems_ItemAdded(object sender, PaletteItem item)
        {
            CreatePaletteEditItem(item);
            this.Invalidate();
        }

        void PaletteItems_ItemRemoved(object sender, PaletteItem item)
        {
            m_editItems.Remove(item);
            this.Invalidate();
        }

        void PaletteItems_ItemsCleared(object sender, EventArgs e)
        {
            m_editItems.Clear();
            this.Invalidate();
        }

        void editItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is PaletteEditItem)
            {
                PaletteEditItem p = (PaletteEditItem)sender;

                if (!p.IsMoving)
                {
                    DeselectItems();

                    p.Select();
                    m_selectedItems.Add(p);
                }
            }

            this.Invalidate();
        }
        #endregion

        #region Method Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            DeselectItems();
        }
        #endregion
    }
}
