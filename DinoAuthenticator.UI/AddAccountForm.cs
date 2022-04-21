using DinoAuthenticator.AccountsTotp;
using System.Text.RegularExpressions;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace DinoAuthenticator.UI;

public partial class AddAccountForm : Form
{
    private static readonly Regex OTPAUTH_URI_REGEX = new Regex(
        @"^otpauth:\/\/(?:totp|hotp)\/(?:.+)\?secret=(?<secret>.+)&issuer=(?:.*)$",
        RegexOptions.Compiled);

    private AccountsManager accountsManager;

    public AddAccountForm(AccountsManager accountsManager) : base()
    {
        InitializeComponent();

        this.accountsManager = accountsManager;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        string accountName = this.accountNameInput.Text;
        string secretKeyInput = this.secretKeyInput.Text;

        if (accountName.Trim() != "" && secretKeyInput.Trim() != "")
        {
            Account account = new Account(accountName, secretKeyInput);

            try
            {
                this.accountsManager.SaveAccount(account);
            }
            catch (Exception)
            {
                MessageBox.Show("An error has ocurred while trying to save account");
            }

            this.Close();
        }
    }

    private static string? TryDecodeQrBitmap(Bitmap bitmap)
    {
        LuminanceSource source = new BitmapLuminanceSource(bitmap);
        HybridBinarizer hybridBinarizer = new HybridBinarizer(source);
        BinaryBitmap binaryBitmap = new BinaryBitmap(hybridBinarizer);
        MultiFormatReader reader = new MultiFormatReader();
        Result result = reader.decode(binaryBitmap);

        return (result != null) ? result.Text : null;
    }

    private static string TryGetSecretKeyFromUriFormatOrRaw(string rawSecretKey)
    {
        Match match = AddAccountForm.OTPAUTH_URI_REGEX.Match(rawSecretKey);
        if (match.Success)
        {
            Group secretGroup = match.Groups["secret"];
            return secretGroup.Value;
        }
        else
        {
            return rawSecretKey;
        }
    }

    private void importPrivateKeyButton_Click(object sender, EventArgs e)
    {
        if (Clipboard.ContainsImage()) 
        { 
            Image clipboardImage = Clipboard.GetImage();
            this.clipboardQrCodePictureBox.Image = clipboardImage;
            Clipboard.Clear();

            Bitmap qrBitmap = (Bitmap)clipboardImage;
            string? secretKey = AddAccountForm.TryDecodeQrBitmap(qrBitmap);

            if (secretKey != null)
            {
                this.secretKeyInput.Text = AddAccountForm.TryGetSecretKeyFromUriFormatOrRaw(secretKey);
            }
        }
        else
        {
            MessageBox.Show("An error has ocurred while trying to import QR code from clipboard");
        }
    }
}
