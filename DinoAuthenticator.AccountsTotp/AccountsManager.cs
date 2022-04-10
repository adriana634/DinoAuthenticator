using OtpNet;
using ProtoBuf;

namespace DinoAuthenticator.AccountsTotp;

public class AccountsManager
{
    private readonly string accountsFilePath;

    public AccountsManager(string accountsFilePath)
    {
        this.accountsFilePath = accountsFilePath;
    }

    private static byte[] ReadAccountsFileBytes(string accountsFilePath)
    {
        using FileStream stream = File.Open(accountsFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

        // Read the source file into a byte array.
        byte[] bytes = new byte[stream.Length];

        int numBytesToRead = (int)stream.Length;
        int numBytesRead = 0;

        while (numBytesToRead > 0)
        {
            // Read may return anything from 0 to numBytesToRead.
            int totalReadBytes = stream.Read(bytes, numBytesRead, numBytesToRead);

            // Break when the end of the file is reached.
            if (totalReadBytes == 0)
                break;

            numBytesRead += totalReadBytes;
            numBytesToRead -= totalReadBytes;
        }

        return bytes;
    }

    private static void WriteAccountsIntoFile(string accountsFilePath, List<Account> accounts)
    {
        using MemoryStream stream = new MemoryStream();
        Serializer.Serialize(stream, accounts);
        byte[] newUnprotectedAccountsFileBytes = stream.ToArray();

        byte[] newProtectedAccountsFileBytes = ProtectedAccountsData.ProtectBytes(newUnprotectedAccountsFileBytes);
        File.WriteAllBytes(accountsFilePath, newProtectedAccountsFileBytes);
    }

    private static List<Account> GetAccounts(string accountsFilePath)
    {
        if (File.Exists(accountsFilePath))
        {
            byte[] protectedAccountsFileBytes = AccountsManager.ReadAccountsFileBytes(accountsFilePath);

            if (protectedAccountsFileBytes.Length > 0)
            {
                byte[] unprotectedAccountsFileBytes = ProtectedAccountsData.UnprotectBytes(protectedAccountsFileBytes);

                using MemoryStream stream = new MemoryStream();

                for (int i = 0; i < unprotectedAccountsFileBytes.Length; i++)
                {
                    byte unprotectedAccountFileByte = unprotectedAccountsFileBytes[i];
                    stream.WriteByte(unprotectedAccountFileByte);
                }

                stream.Position = 0;

                List<Account> accounts = Serializer.Deserialize<List<Account>>(stream);
                return accounts;
            }
            else
            {
                List<Account> accounts = new List<Account>();
                return accounts;
            }
        }
        else
        {
            List<Account> accounts = new List<Account>();
            return accounts;
        }
    }

    public void SaveAccount(Account account)
    {
        List<Account> accounts = AccountsManager.GetAccounts(this.accountsFilePath);
        accounts.Add(account);

        AccountsManager.WriteAccountsIntoFile(accountsFilePath, accounts);
    }

    public string[] GetAccountNames()
    {
        List<Account> accounts = AccountsManager.GetAccounts(this.accountsFilePath);

        string[] accountNames = accounts.Select(account => account.AccountName).ToArray();
        return accountNames;
    }

    public byte[] GetAccountSecretKey(string accountName)
    {
        List<Account> accounts = AccountsManager.GetAccounts(this.accountsFilePath);
        
        Account account = accounts.Find(account => account.AccountName == accountName);
        string accountPrivateKey = account.SecretKey;

        return Base32Encoding.ToBytes(accountPrivateKey);
    }

    public static ComputedTotp ComputeTotp(byte[] secretKey)
    {
        Totp totp = new Totp(secretKey, mode: OtpHashMode.Sha1, step: 30);

        string totpCode = totp.ComputeTotp();
        int totpRemainingSeconds = totp.RemainingSeconds();

        return new ComputedTotp(totpCode, totpRemainingSeconds);
    }
}
