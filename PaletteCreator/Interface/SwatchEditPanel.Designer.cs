namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    partial class SwatchEditPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorGrid1 = new ArbitraryPixel.Applications.PC.PaletteManager.ColorGrid();
            this.SuspendLayout();
            // 
            // colorGrid1
            // 
            this.colorGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorGrid1.Brightness = 118.58823537826538D;
            this.colorGrid1.CurrentColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.colorGrid1.Hue = 120D;
            this.colorGrid1.Location = new System.Drawing.Point(44, 43);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Saturation = 120D;
            this.colorGrid1.ShowSelection = true;
            this.colorGrid1.Size = new System.Drawing.Size(205, 182);
            this.colorGrid1.TabIndex = 0;
            this.colorGrid1.Text = "colorGrid1";
            // 
            // SwatchEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorGrid1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SwatchEditPanel";
            this.Size = new System.Drawing.Size(513, 325);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorGrid colorGrid1;






    }
}
