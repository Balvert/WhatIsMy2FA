using System.Security.Cryptography;
using System.Text;

namespace WhatIsMy2FA;

internal class Encrypter
{
    private const string Key = "A1tyH1AzSWEdDDDJ"; 

    public string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.GenerateIV();

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(aes.IV, 0, aes.IV.Length); // IV opslaan voor decryptie

                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public string Decrypt(string cipherText)
    {
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);

            byte[] iv = new byte[16];
            Array.Copy(fullCipher, iv, iv.Length);
            aes.IV = iv;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(
                    new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length),
                    aes.CreateDecryptor(),
                    CryptoStreamMode.Read))
                {
                    cs.CopyTo(ms);
                }

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}