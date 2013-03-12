using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T NewValue { get; private set; }
        public T OldValue { get; private set; }

        public ValueChangedEventArgs(T newValue, T oldValue)
        {
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }
    }
}
