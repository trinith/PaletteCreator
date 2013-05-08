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
            this.verticalSlider1 = new ArbitraryPixel.Applications.PC.PaletteManager.VerticalSlider();
            this.SuspendLayout();
            // 
            // colorGrid1
            // 
            this.colorGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorGrid1.Brightness = 119.52941179275513D;
            this.colorGrid1.CurrentColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.colorGrid1.Hue = 120D;
            this.colorGrid1.Location = new System.Drawing.Point(215, 72);
            this.colorGrid1.MaximumSize = new System.Drawing.Size(240, 240);
            this.colorGrid1.MinimumSize = new System.Drawing.Size(240, 240);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Saturation = 120D;
            this.colorGrid1.ShowSelection = true;
            this.colorGrid1.Size = new System.Drawing.Size(240, 240);
            this.colorGrid1.TabIndex = 2;
            this.colorGrid1.Text = "colorGrid1";
            // 
            // verticalSlider1
            // 
            this.verticalSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.verticalSlider1.BackColor = System.Drawing.SystemColors.Control;
            this.verticalSlider1.Location = new System.Drawing.Point(185, 72);
            this.verticalSlider1.Maximum = 100D;
            this.verticalSlider1.Minimum = 0D;
            this.verticalSlider1.Name = "verticalSlider1";
            this.verticalSlider1.Padding = new System.Windows.Forms.Padding(5);
            this.verticalSlider1.Size = new System.Drawing.Size(24, 240);
            this.verticalSlider1.TabIndex = 1;
            this.verticalSlider1.Text = "verticalSlider1";
            this.verticalSlider1.Value = 50D;
            // 
            // SwatchEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorGrid1);
            this.Controls.Add(this.verticalSlider1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SwatchEditPanel";
            this.Size = new System.Drawing.Size(684, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private VerticalSlider verticalSlider1;
        private ColorGrid colorGrid1;






    }
}
