using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class Palette
    {
        #region Public Properties
        public string Name { get; set; }
        public PaletteItemCollection PaletteItems { get; private set;  }
        #endregion

        #region Constructors
        public Palette(string name)
            : this(name, null)
        {
        }

        public Palette(string name, IEnumerable<PaletteItem> items)
        {
            this.PaletteItems = new PaletteItemCollection();

            this.Name = name;

            if (items != null)
                this.PaletteItems.AddRange(items);
        }
        #endregion
    }
}
