# What is my 2FA?

What is my 2FA is a simple OTP tool where you can store your 2FA codes.

This app supports standard OTP URIs:
otpauth://totp/Issuer:Account?secret=BASE32SECRET&issuer=Issuer

I use the tool personally to quickly get my 2FA secret and to have a backup on my PC and laptop.

The application is build using .NET 10 and WinForm.

Note: the application stores the files encrypted, but the key is stored in the code and can be used to decrypt the file. **It is recommended to change the key in the code before using the application.**

## How to use
1. Start the application
2. Click on the "Add" button
3. Scan the QR code with a QR code scanner app  like QR Bot
4. Copy and paste the code to your PC
5. Paste the code in the secret field and click on "Save"
6. Save the file to your desired location

## Technologies
C#
Windows Forms
.NET 10

## Packages
This project uses the Otp.NET package from nuget.
https://www.nuget.org/packages/Otp.NET

## License
This project has no license and can be used for personal use.
