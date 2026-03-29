namespace WhatIsMy2FA
{
    partial class WhatIsMy2FAForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CodesListBox = new ListBox();
            menuStrip1 = new MenuStrip();
            loadToolStripMenuItem = new ToolStripMenuItem();
            OpenFileMenuItem = new ToolStripMenuItem();
            SaveFileMenuItem = new ToolStripMenuItem();
            SaveFileAsMenuItem = new ToolStripMenuItem();
            AddQRCodeMenuItem = new ToolStripMenuItem();
            CopySecretMenuItem = new ToolStripMenuItem();
            DeleteMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // CodesListBox
            // 
            CodesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CodesListBox.Font = new Font("Segoe UI", 12F);
            CodesListBox.FormattingEnabled = true;
            CodesListBox.Location = new Point(12, 27);
            CodesListBox.Name = "CodesListBox";
            CodesListBox.Size = new Size(776, 403);
            CodesListBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadToolStripMenuItem, AddQRCodeMenuItem, CopySecretMenuItem, DeleteMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "MainMenuStrip";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenFileMenuItem, SaveFileMenuItem, SaveFileAsMenuItem });
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(37, 20);
            loadToolStripMenuItem.Text = "&File";
            // 
            // OpenFileMenuItem
            // 
            OpenFileMenuItem.Name = "OpenFileMenuItem";
            OpenFileMenuItem.Size = new Size(112, 22);
            OpenFileMenuItem.Text = "&Open";
            OpenFileMenuItem.Click += OpenFileMenuItem_Click;
            // 
            // SaveFileMenuItem
            // 
            SaveFileMenuItem.Name = "SaveFileMenuItem";
            SaveFileMenuItem.Size = new Size(112, 22);
            SaveFileMenuItem.Text = "&Save";
            SaveFileMenuItem.Click += SaveFileMenuItem_Click;
            // 
            // SaveFileAsMenuItem
            // 
            SaveFileAsMenuItem.Name = "SaveFileAsMenuItem";
            SaveFileAsMenuItem.Size = new Size(112, 22);
            SaveFileAsMenuItem.Text = "S&ave as";
            SaveFileAsMenuItem.Click += SaveFileAsMenuItem_Click;
            // 
            // AddQRCodeMenuItem
            // 
            AddQRCodeMenuItem.Name = "AddQRCodeMenuItem";
            AddQRCodeMenuItem.Size = new Size(91, 20);
            AddQRCodeMenuItem.Text = "Add QR Code";
            AddQRCodeMenuItem.Click += AddQRCodeMenuItem_Click;
            // 
            // CopySecretMenuItem
            // 
            CopySecretMenuItem.Name = "CopySecretMenuItem";
            CopySecretMenuItem.Size = new Size(81, 20);
            CopySecretMenuItem.Text = "Copy secret";
            CopySecretMenuItem.Click += CopySecretMenuItem_Click;
            // 
            // DeleteMenuItem
            // 
            DeleteMenuItem.Name = "DeleteMenuItem";
            DeleteMenuItem.Size = new Size(52, 20);
            DeleteMenuItem.Text = "Delete";
            DeleteMenuItem.Click += DeleteMenuItem_Click;
            // 
            // WhatIsMy2FAForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CodesListBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "WhatIsMy2FAForm";
            Text = "What is my 2FA";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox CodesListBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem AddQRCodeMenuItem;
        private ToolStripMenuItem OpenFileMenuItem;
        private ToolStripMenuItem SaveFileMenuItem;
        private ToolStripMenuItem SaveFileAsMenuItem;
        private ToolStripMenuItem CopySecretMenuItem;
        private ToolStripMenuItem DeleteMenuItem;
    }
}
