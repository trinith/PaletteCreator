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
    public partial class PaletteEditorToolbar : UserControl
    {
        private ColorOutputType m_outputType = ColorOutputType.Hex;

        public PaletteEditorToolbar()
        {
            InitializeComponent();

            m_cbOutputType.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(ColorOutputType)))
                m_cbOutputType.Items.Add(s);

            m_cbOutputType.SelectedIndex = 0;
        }

        public ColorOutputType OutputType
        {
            set
            {
                ColorOutputType old = m_outputType;
                m_outputType = value;

                if (this.OutputTypeChanged != null)
                    this.OutputTypeChanged(this, new ValueChangedEventArgs<ColorOutputType>(old, value));
            }
            get { return m_outputType; }
        }

        public event EventHandler NewSelected;
        public event EventHandler RemoveSelected;
        public event ColorOutputTypeChangedEventHandler OutputTypeChanged;

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            if (this.NewSelected != null)
                this.NewSelected(this, new EventArgs());
        }

        private void m_btnRemoveActive_Click(object sender, EventArgs e)
        {
            if (this.RemoveSelected != null)
                this.RemoveSelected(this, new EventArgs());
        }

        private void m_cbOutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OutputType = (ColorOutputType)Enum.Parse(typeof(ColorOutputType), m_cbOutputType.SelectedItem.ToString());
        }
    }

    public delegate void ColorOutputTypeChangedEventHandler(object sender, ValueChangedEventArgs<ColorOutputType> args);
}
