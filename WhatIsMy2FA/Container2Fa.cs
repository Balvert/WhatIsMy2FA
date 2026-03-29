using System.Text.Json.Serialization;
using OtpNet;

namespace WhatIsMy2FA;

internal class Container2FA
{
    public string Issuer { get; private set; } 
    public string QRCode { get; private set; }

    [JsonIgnore]
    public string Secret { get; private set; } = String.Empty;

    public Container2FA(string QRCode, string Issuer)
    {
        this.QRCode = QRCode;
        this.Issuer = Issuer;
        Refresh();
    }

    public bool Refresh()
    {
        try
        {
            var bytes = Base32Encoding.ToBytes(QRCode);
            var topt = new Totp(bytes);
            var newSecret = topt.ComputeTotp();

            if (newSecret != Secret)
            {
                Secret = newSecret;
                return true;
            }
        }

        catch 
        { 
            Secret = "**error**";
        }

        return false;
    }

    public override string ToString()
    {
        return $"{Issuer}   [{Secret}]";
    }
}
