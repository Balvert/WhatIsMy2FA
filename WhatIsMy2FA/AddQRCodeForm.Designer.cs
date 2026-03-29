namespace WhatIsMy2FA
{
    partial class AddQRCodeForm
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
            PastButton = new Button();
            SaveButton = new Button();
            QRCodeTextBox = new TextBox();
            label1 = new Label();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // PastButton
            // 
            PastButton.Location = new Point(12, 56);
            PastButton.Name = "PastButton";
            PastButton.Size = new Size(75, 23);
            PastButton.TabIndex = 0;
            PastButton.Text = "&Paste";
            PastButton.UseVisualStyleBackColor = true;
            PastButton.Click += PastButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SaveButton.Enabled = false;
            SaveButton.Location = new Point(386, 56);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Sae";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // QRCodeTextBox
            // 
            QRCodeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            QRCodeTextBox.Location = new Point(12, 27);
            QRCodeTextBox.Name = "QRCodeTextBox";
            QRCodeTextBox.Size = new Size(530, 23);
            QRCodeTextBox.TabIndex = 0;
            QRCodeTextBox.TextChanged += QRCodeTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 3;
            label1.Text = "Paste your QR Code here:";
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CancelButton.Location = new Point(467, 56);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddQRCodeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 88);
            ControlBox = false;
            Controls.Add(CancelButton);
            Controls.Add(label1);
            Controls.Add(QRCodeTextBox);
            Controls.Add(SaveButton);
            Controls.Add(PastButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddQRCodeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddQRCodeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PastButton;
        private Button SaveButton;
        private TextBox QRCodeTextBox;
        private Label label1;
        private Button CancelButton;
    }
}