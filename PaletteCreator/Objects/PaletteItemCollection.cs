using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class PaletteItemCollection : ICollection<PaletteItem>
    {
        #region Private Members
        private List<PaletteItem> m_items = new List<PaletteItem>();
        #endregion

        #region Delegates
        public delegate void ItemActionEventHandler(object sender, PaletteItem item);
        #endregion

        #region Events
        public event EventHandler ItemsCleared;
        public event ItemActionEventHandler ItemAdded;
        public event ItemActionEventHandler ItemRemoved;
        #endregion

        #region ICollection<PaletteItem> Implementation
        public void Add(PaletteItem item)
        {
            m_items.Add(item);

            if (this.ItemAdded != null)
                this.ItemAdded(this, item);
        }

        public bool Remove(PaletteItem item)
        {
            bool retVal = m_items.Remove(item);

            if (this.ItemRemoved != null)
                this.ItemRemoved(this, item);

            return retVal;
        }

        public void Clear()
        {
            m_items.Clear();

            if (this.ItemsCleared != null)
                this.ItemsCleared(this, new EventArgs());
        }

        public bool Contains(PaletteItem item)
        {
            return m_items.Contains(item);
        }

        public void CopyTo(PaletteItem[] array, int arrayIndex)
        {
            m_items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_items.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<PaletteItem>)m_items).IsReadOnly; }
        }

        public IEnumerator<PaletteItem> GetEnumerator()
        {
            return m_items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_items.GetEnumerator();
        }
        #endregion
    }
}
