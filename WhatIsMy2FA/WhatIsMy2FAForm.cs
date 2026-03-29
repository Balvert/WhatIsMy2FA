/* Rene Balvert 2026
 * 
 * WhatIsMy2FA is a simple Windows Forms application that allows users to store and manage their 2FA QR codes. 
 * 
 * The file is encrypted stored, but the key is currencly fixed in the Encrypter class, so anyone having 
 * the code can decrypt the file. 
 * 
 * You can change the KEY or make it dynamic by using a password or something else.
 * 
 * It only works with totp QR codes. 
 * 
 */

using System.ComponentModel;
using System.Text.Json;

namespace WhatIsMy2FA;

public partial class WhatIsMy2FAForm : Form
{
    private string FilePath = String.Empty;
    private string FormTitle;
    private bool _isDirty = false;

    private BindingList<Container2FA> QRCodes = new BindingList<Container2FA>();

    public WhatIsMy2FAForm()
    {
        InitializeComponent();

        FormTitle = this.Text;
        CodesListBox.DataSource = QRCodes;
    }

    private bool SaveFileAs()
    {
        // Open the file dialog to select a file to save
        using var saveFileDialog = new SaveFileDialog();

        saveFileDialog.Filter = "Text files (*.2fa)|*.2fa|All files (*.*)|*.*";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            FilePath = saveFileDialog.FileName;
            new RegistryHelper().Write("Filepath", FilePath);

            return SaveFile();
        }

        return false;
    }

    private bool IsDirty
    {
        get
        {
            return _isDirty;
        }

        set
        {
            _isDirty = value;
            UpdateFormTitle();
        }
    }

    private void UpdateFormTitle()
    {
        string title = $"{FormTitle}   {FilePath}";

        if (_isDirty) title += "*";
        Text = title;
    }

    private void LoadQRCodes(string FilePath)
    {
        try
        {
            // Load all text from the file
            string encryptedData = File.ReadAllText(FilePath);
            Encrypter encrypter = new Encrypter();

            string decryptedData = encrypter.Decrypt(encryptedData);

            QRCodes = new BindingList<Container2FA>(JsonSerializer.Deserialize<BindingList<Container2FA>>(decryptedData) ?? new BindingList<Container2FA>());

            CodesListBox.DataSource = QRCodes;
            QRCodes.ResetBindings();
        }

        catch
        {
            throw;
        }
    }

    private bool SaveFile()
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(QRCodes);
            Encrypter encrypter = new Encrypter();
            string encryptedData = encrypter.Encrypt(jsonData);

            File.WriteAllText(FilePath, encryptedData);
            IsDirty = false;

            return true;
        }
        catch
        {
            MessageBox.Show(this, "An error occurred while saving the file. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return false;
    }

    private void UpdateMenu()
    {
        CopySecretMenuItem.Enabled = CodesListBox.SelectedItem != null;
        DeleteMenuItem.Enabled = CodesListBox.SelectedItem != null;
        SaveFileAsMenuItem.Enabled = QRCodes.Count > 0;
        SaveFileMenuItem.Enabled = QRCodes.Count > 0;
    }

    #region Event Handlers
    /// <summary>
    /// OnShown loads the last saved file if exists.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        // Lets see if we hvae a filefolder
        using var settings = new RegistryHelper();

        FilePath = settings.ReadString("Filepath") ?? String.Empty;

        if (FilePath != String.Empty)
            if (File.Exists(FilePath))
                LoadQRCodes(FilePath);

        UpdateFormTitle();
        UpdateMenu();
    }

    /// <summary>
    /// OnFormClosing warns if there are unsaved changes.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);

        if (IsDirty && QRCodes.Count > 0)
        {
            try
            {
                var result = MessageBox.Show(this, "You have unsaved changes. Do you want to save before exiting?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (FilePath != String.Empty)
                    {
                        if (!SaveFile()) e.Cancel = true;
                    }
                    else
                    {
                        if (!SaveFileAs()) e.Cancel = true;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            catch
            {
                e.Cancel = true;
            }
        }
    }

    private void AddQRCodeMenuItem_Click(object sender, EventArgs e)
    {
        using var addQRCodeForm = new AddQRCodeForm();
        var result = addQRCodeForm.ShowDialog(this);

        if (result == DialogResult.OK)
        {
            try
            {
                // Get the OTP secret and issues from the QR CODE otpauth://totp/GitHub:YourName?secret=ABCDEFGABCDEFGAB&issuer=GitHub
                string[] fields = addQRCodeForm.QRCode.Split('?');

                if (fields.Length < 2) throw new Exception();

                // The first element has the format otpauth://totp/name

                string[] parameters = fields[1].Split('&');
                string secret = parameters.FirstOrDefault(f => f.StartsWith("secret="))?.Substring(7) ?? String.Empty;
                string issuer = fields.FirstOrDefault(f => f.StartsWith("issuer="))?.Substring(7) ?? String.Empty;

                if (issuer == String.Empty) issuer = fields[0].Replace("otpauth://totp/", String.Empty);

                if (QRCodes.Any(q => q.Secret == secret))
                {
                    MessageBox.Show(this, "This QR code already exists in the list.", "Duplicate QR Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var container2FA = new Container2FA(secret, issuer);
                QRCodes.Add(container2FA);
                CodesListBox.SelectedIndex = CodesListBox.Items.Count - 1;

                UpdateMenu();

                IsDirty = true;
            }

            catch
            {
                MessageBox.Show(this, "Invalid QR code format. Please ensure the QR code is in the correct otpauth://totp/ format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Codies the secret of the selected QR code to the clipboard.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CopySecretMenuItem_Click(object sender, EventArgs e)
    {
        if (CodesListBox.SelectedItem != null)
        {
            if (CodesListBox.SelectedItem is Container2FA selectedQRCode)
            {
                Clipboard.SetText(selectedQRCode.Secret);
            }
        }
    }

    private void OpenFileMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            // Show the openfile dialog
            using var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text files (*.2fa)|*.2fa|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadQRCodes(openFileDialog.FileName);
                FilePath = openFileDialog.FileName;

                UpdateFormTitle();
            }
        }

        catch
        {
            MessageBox.Show(this, "An error occurred while opening the file. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveFileMenuItem_Click(object sender, EventArgs e)
    {
        if (FilePath == String.Empty)
        {
            if (SaveFileAs()) IsDirty = true;
        }
        else
        {
            if (SaveFile()) IsDirty = true;
        }
    }

    private void SaveFileAsMenuItem_Click(object sender, EventArgs e)
    {
        SaveFileAs();
        IsDirty = false;
    }

    private void DeleteMenuItem_Click(object sender, EventArgs e)
    {
        if (CodesListBox.SelectedItem != null)
        {
            if (CodesListBox.SelectedItem is Container2FA selectedQRCode)
            {
                var result = MessageBox.Show(this, $"Are you sure you want to delete the QR code for {selectedQRCode.Issuer}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    QRCodes.Remove(selectedQRCode);
                    UpdateMenu();

                    IsDirty = true;
                }
            }
        }
    }
    #endregion
}
