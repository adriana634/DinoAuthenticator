using DinoAuthenticator.AccountsTotp;
using OtpNet;
using System.IO;
using System.Linq;
using Xunit;

namespace DinoAuthenticator.Test;

public class ComputeTotpTest
{
    [Fact]
    public void ComputeRandomTotp()
    {
        byte[] key = KeyGeneration.GenerateRandomKey(20);

        string base32String = Base32Encoding.ToString(key);
        byte[] base32Bytes = Base32Encoding.ToBytes(base32String);

        Totp otp = new Totp(base32Bytes);
        string totp = otp.ComputeTotp();

        bool isTotpValid = otp.VerifyTotp(totp, out long timeStepMatched);
        Assert.True(isTotpValid);
    }

    [Theory]
    [InlineData("Account 1")]
    [InlineData("Account 2")]
    [InlineData("Account 3")]
    [InlineData("Account 4")]
    [InlineData("Account 5")]
    public void CreateRandomAccountAndComputeTotp(string accountName)
    {
        string accountsFilePath = Path.GetTempFileName();

        try
        {
            AccountsManager accountsManager = new AccountsManager(accountsFilePath);

            byte[] accountSecretKeyToSave = KeyGeneration.GenerateRandomKey(20);
            string accountSecretKeyToSaveBase32 = Base32Encoding.ToString(accountSecretKeyToSave);

            Account account = new Account(accountName, accountSecretKeyToSaveBase32);
            accountsManager.SaveAccount(account);

            string[] accountNames = accountsManager.GetAccountNames();
            Assert.True(accountNames.Length == 1);
            Assert.True(accountNames[0] == accountName);

            byte[] accountSecretKey = accountsManager.GetAccountSecretKey(accountName);
            Assert.True(accountSecretKeyToSave.SequenceEqual(accountSecretKey));

            Totp otp = new Totp(accountSecretKey);
            string totp = otp.ComputeTotp();

            bool isTotpValid = otp.VerifyTotp(totp, out long timeStepMatched);
            Assert.True(isTotpValid);
        }
        finally
        {
            File.Delete(accountsFilePath);
        }
    }
}
