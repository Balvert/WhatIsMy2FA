using Microsoft.Win32;

namespace WhatIsMy2FA;

public class RegistryHelper : IDisposable
{
    private readonly RegistryKey registry;
    private bool disposed;

    public RegistryHelper()
    {
        registry = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WhatIsMy2FA");
    }

    public void Write(string key, string value)
    {
        registry.SetValue(key, value);
    }

    public string? ReadString(string key)
    {
        var v = registry.GetValue(key);

        return v as string;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                registry?.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
