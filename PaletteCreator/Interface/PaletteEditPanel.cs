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
        #region Private Enums
        private enum State
        {
            Editing,
            Creating,
            Deleting
        }
        #endregion

        #region Private Members
        private Palette m_targetPalette = null;
        private Dictionary<PaletteItem, PaletteEditItem> m_editItems = new Dictionary<PaletteItem, PaletteEditItem>();
        private List<PaletteEditItem> m_selectedItems = new List<PaletteEditItem>();
        private State m_state = State.Editing;
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

        public Color DefaultSwatchColor { get; set; }
        public Color DefaultBackgroundColor { get; set; }
        #endregion

        #region Constructors
        public PaletteEditPanel()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.DefaultSwatchColor = Color.Black;
            this.DefaultBackgroundColor = SystemColors.WindowFrame;
            this.BackColor = this.DefaultBackgroundColor;
        }
        #endregion

        #region Private Methods
        private void RemoveAndCleanItem(PaletteEditItem pei, bool forceUpdate = false)
        {
            PaletteItem targetItem = pei.TargetPaletteItem;

            if (m_targetPalette.PaletteItems.Contains(targetItem))
                m_targetPalette.PaletteItems.Remove(targetItem);

            m_editItems.Remove(targetItem);
            this.Controls.Remove(pei);

            if (forceUpdate)
            {
                this.Invalidate();
            }
        }

        private void CreateNewSwatch(Point insertionPoint)
        {
            if (m_targetPalette != null)
            {
                PaletteItem newItem = new PaletteItem("New Item", this.DefaultSwatchColor);
                m_targetPalette.PaletteItems.Add(newItem);
                CreatePaletteEditItem(newItem, insertionPoint).BringToFront();
            }
        }

        private Point GetInsertionPoint()
        {
            Point p = new Point(8, 8);

            if (m_editItems.Count > 0)
            {
                PaletteItem keyItem = m_editItems.Keys.Select(x => x).ToArray()[m_editItems.Count - 1];
                PaletteEditItem pei = m_editItems[keyItem];
                p = new Point(
                    pei.Location.X + pei.Size.Width / 2,
                    pei.Location.Y + pei.Size.Height / 4
                );
            }

            return p;
        }

        private PaletteEditItem CreatePaletteEditItem(PaletteItem item, Point insertionPoint)
        {
            PaletteEditItem editItem = new PaletteEditItem(item);
            editItem.Location = insertionPoint;
            editItem.MouseClick += new MouseEventHandler(editItem_MouseClick);
            editItem.GotFocus += new EventHandler(editItem_GotFocus);
            editItem.LostFocus += new EventHandler(editItem_LostFocus);

            m_editItems.Add(item, editItem);
            this.Controls.Add(editItem);

            return editItem;
        }

        private void SetupEventsAndItems()
        {
            if (m_targetPalette != null)
            {
                foreach (PaletteItem p in m_targetPalette.PaletteItems)
                {
                    Point insertionPoint = GetInsertionPoint();
                    CreatePaletteEditItem(p, insertionPoint);
                }

                //m_targetPalette.PaletteItems.ItemAdded += new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemAdded);
                //m_targetPalette.PaletteItems.ItemRemoved += new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemRemoved);
                //m_targetPalette.PaletteItems.ItemsCleared += new EventHandler(PaletteItems_ItemsCleared);
            }
        }

        private void TearDownEventsAndItems()
        {
            this.Controls.Clear();
            m_editItems.Clear();

            if (m_targetPalette != null)
            {
                //m_targetPalette.PaletteItems.ItemAdded -= new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemAdded);
                //m_targetPalette.PaletteItems.ItemRemoved -= new PaletteItemCollection.ItemActionEventHandler(PaletteItems_ItemRemoved);
                //m_targetPalette.PaletteItems.ItemsCleared -= new EventHandler(PaletteItems_ItemsCleared);
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
        public void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            // Have to publicly expose this since apparently panels don't like to handle input. We instead
            // have to have the parent call this. Weird...
            if (this.ContainsFocus)
            {
                switch ((Keys)e.KeyChar)
                {
                    case Keys.Escape:
                        switch (m_state)
                        {
                            case State.Creating:
                                EndCreateMode();
                                break;
                            case State.Deleting:
                                EndRemoveMode();
                                break;
                            case State.Editing:
                                DeselectItems();
                                break;
                        }
                        break;
                }
            }
        }

        public void BeginCreateMode()
        {
            m_state = State.Creating;
            this.Cursor = Cursors.Cross;

            foreach (PaletteEditItem pei in this.Controls)
                pei.IsInteractive = false;
        }

        public void EndCreateMode()
        {
            foreach (PaletteEditItem pei in this.Controls)
                pei.IsInteractive = true;

            this.Cursor = Cursors.Default;
            m_state = State.Editing;
        }

        public void BeginRemoveMode()
        {
            if (m_selectedItems.Count > 0)
            {
                if (m_targetPalette != null)
                {
                    // Items are selected, we can just remove them.
                    foreach (PaletteEditItem pei in m_selectedItems)
                    {
                        RemoveAndCleanItem(pei);
                    }

                    m_selectedItems.Clear();
                    this.Invalidate();
                }
            }
            else
            {
                // No items are selected, enter remove mode.
                m_state = State.Deleting;
                this.Cursor = Cursors.Cross;

                foreach (PaletteEditItem pei in this.Controls)
                    pei.IsMovable = false;
            }
        }

        public void EndRemoveMode()
        {
            foreach (PaletteEditItem pei in this.Controls)
                pei.IsMovable = true;

            this.Cursor = Cursors.Default;
            m_state = State.Editing;
        }
        #endregion

        #region Event Handlers
        void PaletteItems_ItemAdded(object sender, PaletteItem item)
        {
            CreatePaletteEditItem(item, GetInsertionPoint());
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

                switch (m_state)
                {
                    case State.Editing:
                        if (!p.IsMoving && e.Button == MouseButtons.Left)
                        {
                            if (Keyboard.GetState().IsKeyUp(Keys.ControlKey))
                                DeselectItems();

                            p.Select();
                            m_selectedItems.Add(p);
                        }
                        this.Invalidate();

                        break;
                    case State.Creating:
                        CreateNewSwatch(new Point(p.Location.X + e.Location.X, p.Location.Y + e.Location.Y));
                        EndCreateMode();
                        break;
                    case State.Deleting:
                        RemoveAndCleanItem(p, true);
                        EndRemoveMode();
                        break;
                }
            }
        }

        void editItem_LostFocus(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        void editItem_GotFocus(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion

        #region Method Overrides
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.ContainsFocus)
            {
                Rectangle focusRect = new Rectangle(
                    this.ClientRectangle.X + 1,
                    this.ClientRectangle.Y + 1,
                    this.ClientRectangle.Width - 2,
                    this.ClientRectangle.Height - 2
                );

                Color focusColor = Color.LightYellow;
                if (this.BackColor.GetBrightness() > 0.5f)
                    focusColor = Color.DarkGray;

                e.Graphics.DrawRectangle(new Pen(focusColor), focusRect);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.Focus();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (m_state)
                    {
                        case State.Editing:
                            DeselectItems();
                            break;
                        case State.Creating:
                            CreateNewSwatch(e.Location);
                            EndCreateMode();
                            break;
                        case State.Deleting:
                            EndRemoveMode();
                            break;
                    }
                    break;
            }
        }
        #endregion
    }
}
