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
            this.colorGrid1 = new ArbitraryPixel.Applications.PC.PaletteManager.Interface.ColorGrid();
            this.SuspendLayout();
            // 
            // colorGrid1
            // 
            this.colorGrid1.Location = new System.Drawing.Point(118, 31);
            this.colorGrid1.MaximumSize = new System.Drawing.Size(240, 240);
            this.colorGrid1.MinimumSize = new System.Drawing.Size(240, 240);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Size = new System.Drawing.Size(240, 240);
            this.colorGrid1.TabIndex = 0;
            this.colorGrid1.Text = "colorGrid1";
            // 
            // SwatchEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorGrid1);
            this.Name = "SwatchEditPanel";
            this.Size = new System.Drawing.Size(684, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private Interface.ColorGrid colorGrid1;



    }
}
