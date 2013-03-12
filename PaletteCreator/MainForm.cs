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
        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            PaletteItem i = new PaletteItem("blah", Color.Yellow);
            Console.WriteLine(i.HexColor);
            Console.WriteLine(i.RGBColor);
        }

        private void m_tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
