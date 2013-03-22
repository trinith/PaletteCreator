namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_msMainMenu = new System.Windows.Forms.MenuStrip();
            this.m_tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_scLeftRight = new System.Windows.Forms.SplitContainer();
            this.m_tvPaletteList = new System.Windows.Forms.TreeView();
            this.m_scTopBottom = new System.Windows.Forms.SplitContainer();
            this.m_pepPaletteEditor = new ArbitraryPixel.Applications.PC.PaletteManager.PaletteEditPanel();
            this.m_petEditorToolbar = new ArbitraryPixel.Applications.PC.PaletteManager.PaletteEditorToolbar();
            this.swatchEditPanel1 = new ArbitraryPixel.Applications.PC.PaletteManager.SwatchEditPanel();
            this.m_msMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_scLeftRight)).BeginInit();
            this.m_scLeftRight.Panel1.SuspendLayout();
            this.m_scLeftRight.Panel2.SuspendLayout();
            this.m_scLeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_scTopBottom)).BeginInit();
            this.m_scTopBottom.Panel1.SuspendLayout();
            this.m_scTopBottom.Panel2.SuspendLayout();
            this.m_scTopBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_msMainMenu
            // 
            this.m_msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsmiFile});
            this.m_msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_msMainMenu.Name = "m_msMainMenu";
            this.m_msMainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.m_msMainMenu.Size = new System.Drawing.Size(736, 24);
            this.m_msMainMenu.TabIndex = 0;
            this.m_msMainMenu.Text = "menuStrip1";
            // 
            // m_tsmiFile
            // 
            this.m_tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsmiExit});
            this.m_tsmiFile.Name = "m_tsmiFile";
            this.m_tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.m_tsmiFile.Text = "&File";
            // 
            // m_tsmiExit
            // 
            this.m_tsmiExit.Name = "m_tsmiExit";
            this.m_tsmiExit.Size = new System.Drawing.Size(92, 22);
            this.m_tsmiExit.Text = "E&xit";
            this.m_tsmiExit.Click += new System.EventHandler(this.m_tsmiExit_Click);
            // 
            // m_scLeftRight
            // 
            this.m_scLeftRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_scLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_scLeftRight.Location = new System.Drawing.Point(0, 24);
            this.m_scLeftRight.Margin = new System.Windows.Forms.Padding(2);
            this.m_scLeftRight.Name = "m_scLeftRight";
            // 
            // m_scLeftRight.Panel1
            // 
            this.m_scLeftRight.Panel1.Controls.Add(this.m_tvPaletteList);
            // 
            // m_scLeftRight.Panel2
            // 
            this.m_scLeftRight.Panel2.Controls.Add(this.m_scTopBottom);
            this.m_scLeftRight.Size = new System.Drawing.Size(736, 589);
            this.m_scLeftRight.SplitterDistance = 161;
            this.m_scLeftRight.SplitterWidth = 3;
            this.m_scLeftRight.TabIndex = 1;
            // 
            // m_tvPaletteList
            // 
            this.m_tvPaletteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tvPaletteList.Location = new System.Drawing.Point(0, 0);
            this.m_tvPaletteList.Margin = new System.Windows.Forms.Padding(2);
            this.m_tvPaletteList.Name = "m_tvPaletteList";
            this.m_tvPaletteList.Size = new System.Drawing.Size(157, 585);
            this.m_tvPaletteList.TabIndex = 2;
            // 
            // m_scTopBottom
            // 
            this.m_scTopBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_scTopBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_scTopBottom.Location = new System.Drawing.Point(0, 0);
            this.m_scTopBottom.Margin = new System.Windows.Forms.Padding(2);
            this.m_scTopBottom.Name = "m_scTopBottom";
            this.m_scTopBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_scTopBottom.Panel1
            // 
            this.m_scTopBottom.Panel1.Controls.Add(this.m_pepPaletteEditor);
            this.m_scTopBottom.Panel1.Controls.Add(this.m_petEditorToolbar);
            // 
            // m_scTopBottom.Panel2
            // 
            this.m_scTopBottom.Panel2.Controls.Add(this.swatchEditPanel1);
            this.m_scTopBottom.Size = new System.Drawing.Size(572, 589);
            this.m_scTopBottom.SplitterDistance = 331;
            this.m_scTopBottom.SplitterWidth = 3;
            this.m_scTopBottom.TabIndex = 0;
            // 
            // m_pepPaletteEditor
            // 
            this.m_pepPaletteEditor.AutoScroll = true;
            this.m_pepPaletteEditor.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.m_pepPaletteEditor.DefaultBackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.m_pepPaletteEditor.DefaultSwatchColor = System.Drawing.Color.Black;
            this.m_pepPaletteEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pepPaletteEditor.Location = new System.Drawing.Point(0, 24);
            this.m_pepPaletteEditor.Margin = new System.Windows.Forms.Padding(2);
            this.m_pepPaletteEditor.Name = "m_pepPaletteEditor";
            this.m_pepPaletteEditor.Size = new System.Drawing.Size(568, 303);
            this.m_pepPaletteEditor.TabIndex = 1;
            this.m_pepPaletteEditor.TargetPalette = null;
            // 
            // m_petEditorToolbar
            // 
            this.m_petEditorToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_petEditorToolbar.Location = new System.Drawing.Point(0, 0);
            this.m_petEditorToolbar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_petEditorToolbar.Name = "m_petEditorToolbar";
            this.m_petEditorToolbar.OutputType = ArbitraryPixel.Applications.PC.PaletteManager.ColorOutputType.Hex;
            this.m_petEditorToolbar.Size = new System.Drawing.Size(568, 24);
            this.m_petEditorToolbar.TabIndex = 0;
            this.m_petEditorToolbar.NewSelected += new System.EventHandler(this.m_petEditorToolbar_NewSelected);
            this.m_petEditorToolbar.RemoveSelected += new System.EventHandler(this.m_petEditorToolbar_RemoveSelected);
            // 
            // swatchEditPanel1
            // 
            this.swatchEditPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.swatchEditPanel1.Location = new System.Drawing.Point(0, 0);
            this.swatchEditPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.swatchEditPanel1.Name = "swatchEditPanel1";
            this.swatchEditPanel1.Size = new System.Drawing.Size(568, 251);
            this.swatchEditPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 613);
            this.Controls.Add(this.m_scLeftRight);
            this.Controls.Add(this.m_msMainMenu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.m_msMainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Palette Creator";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.m_msMainMenu.ResumeLayout(false);
            this.m_msMainMenu.PerformLayout();
            this.m_scLeftRight.Panel1.ResumeLayout(false);
            this.m_scLeftRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_scLeftRight)).EndInit();
            this.m_scLeftRight.ResumeLayout(false);
            this.m_scTopBottom.Panel1.ResumeLayout(false);
            this.m_scTopBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_scTopBottom)).EndInit();
            this.m_scTopBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem m_tsmiExit;
        private System.Windows.Forms.SplitContainer m_scLeftRight;
        private System.Windows.Forms.SplitContainer m_scTopBottom;
        private System.Windows.Forms.TreeView m_tvPaletteList;
        private PaletteEditorToolbar m_petEditorToolbar;
        private PaletteEditPanel m_pepPaletteEditor;
        private SwatchEditPanel swatchEditPanel1;
    }
}

