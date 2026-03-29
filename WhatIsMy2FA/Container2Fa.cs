
using OtpNet;

namespace WhatIsMy2FA;

internal class Container2FA
{
    public string Issuer { get; private set; } 
    public string QRCode { get; private set; } 
    public string Secret { get; private set; } = String.Empty;

    public Container2FA(string QRCode, string Issuer)
    {
        this.QRCode = QRCode;
        this.Issuer = Issuer;
        Refresh();
    }


    public void Refresh()
    {
        try
        {
            var bytes = Base32Encoding.ToBytes(QRCode);
            var topt = new Totp(bytes);
            Secret = topt.ComputeTotp();
        }

        catch 
        { 
            Secret = "**error**";
        }
    }

    public override string ToString()
    {
        return $"{Issuer}   [{Secret}]";
    }
}
