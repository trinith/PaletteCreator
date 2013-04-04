namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    partial class PaletteEditorToolbar
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
            this.m_btnNew = new System.Windows.Forms.Button();
            this.m_btnRemoveActive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cbOutputType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_btnNew
            // 
            this.m_btnNew.Location = new System.Drawing.Point(3, 3);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Size = new System.Drawing.Size(75, 23);
            this.m_btnNew.TabIndex = 0;
            this.m_btnNew.Text = "New";
            this.m_btnNew.UseVisualStyleBackColor = true;
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // m_btnRemoveActive
            // 
            this.m_btnRemoveActive.Location = new System.Drawing.Point(84, 3);
            this.m_btnRemoveActive.Name = "m_btnRemoveActive";
            this.m_btnRemoveActive.Size = new System.Drawing.Size(75, 23);
            this.m_btnRemoveActive.TabIndex = 1;
            this.m_btnRemoveActive.Text = "Remove";
            this.m_btnRemoveActive.UseVisualStyleBackColor = true;
            this.m_btnRemoveActive.Click += new System.EventHandler(this.m_btnRemoveActive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Type";
            // 
            // m_cbOutputType
            // 
            this.m_cbOutputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbOutputType.FormattingEnabled = true;
            this.m_cbOutputType.Location = new System.Drawing.Point(258, 3);
            this.m_cbOutputType.Name = "m_cbOutputType";
            this.m_cbOutputType.Size = new System.Drawing.Size(156, 24);
            this.m_cbOutputType.TabIndex = 3;
            this.m_cbOutputType.SelectedIndexChanged += new System.EventHandler(this.m_cbOutputType_SelectedIndexChanged);
            // 
            // PaletteEditorToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_cbOutputType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnRemoveActive);
            this.Controls.Add(this.m_btnNew);
            this.Name = "PaletteEditorToolbar";
            this.Size = new System.Drawing.Size(506, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnNew;
        private System.Windows.Forms.Button m_btnRemoveActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbOutputType;
    }
}
