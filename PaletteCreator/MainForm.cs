using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    public partial class MainForm : Form
    {
        private Palette m_activePalette;
        private List<Palette> m_palettes = new List<Palette>();

        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            m_activePalette = new Palette("Gary Test");
            m_activePalette.PaletteItems.Add(new PaletteItem("Red", Color.Red));
            
            m_palettes.Add(m_activePalette);
            m_pepPaletteEditor.TargetPalette = m_activePalette;
        }

        private void m_tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
