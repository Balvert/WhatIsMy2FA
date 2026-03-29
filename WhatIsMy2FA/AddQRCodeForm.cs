namespace WhatIsMy2FA;

public partial class AddQRCodeForm : Form
{
    public string QRCode { get; private set; } = String.Empty;

    public AddQRCodeForm()
    {
        InitializeComponent();
    }

    private void PastButton_Click(object sender, EventArgs e)
    {
        // Check if clipboard contains text
        if (Clipboard.ContainsText())
        {
            QRCodeTextBox.Text = Clipboard.GetText();
        }
        else
        {
            MessageBox.Show("Clipboard does not contain text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        if (Clipboard.ContainsText())
            QRCodeTextBox.Text = Clipboard.GetText();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        QRCode = QRCodeTextBox.Text;
        DialogResult = DialogResult.OK;
    }

    private void QRCodeTextBox_TextChanged(object sender, EventArgs e)
    {
        if (QRCodeTextBox.Text.StartsWith("otpauth://totp/") && QRCodeTextBox.Text.Contains("?secret="))
        {
            SaveButton.Enabled = true;
        }
        else
        {
            SaveButton.Enabled = false;
        }
    }
}
