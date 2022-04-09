using OtpNet;
using ProtoBuf;

namespace DinoAuthenticator;

internal static class AccountsManager
{
    private static readonly string ACCOUNTS_FILE_NAME = "accounts.bin";

    private static byte[] ReadAccountsFileBytes()
    {
        using FileStream stream = File.Open(AccountsManager.ACCOUNTS_FILE_NAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

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

    private static void WriteAccountsIntoFile(List<Account> accounts)
    {
        using MemoryStream stream = new MemoryStream();
        Serializer.Serialize(stream, accounts);
        byte[] newUnprotectedAccountsFileBytes = stream.ToArray();

        byte[] newProtectedAccountsFileBytes = ProtectedAccountsData.ProtectBytes(newUnprotectedAccountsFileBytes);
        File.WriteAllBytes(AccountsManager.ACCOUNTS_FILE_NAME, newProtectedAccountsFileBytes);
    }

    private static List<Account> GetAccounts()
    {
        if (File.Exists(AccountsManager.ACCOUNTS_FILE_NAME))
        {
            byte[] protectedAccountsFileBytes = AccountsManager.ReadAccountsFileBytes();

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

    internal static void SaveAccount(Account account)
    {
        List<Account> accounts = AccountsManager.GetAccounts();
        accounts.Add(account);

        WriteAccountsIntoFile(accounts);
    }

    internal static string[] GetAccountNames()
    {
        List<Account> accounts = AccountsManager.GetAccounts();

        string[] accountNames = accounts.Select(account => account.AccountName).ToArray();
        return accountNames;
    }

    internal static byte[] GetAccountSecretKey(string accountName)
    {
        List<Account> accounts = AccountsManager.GetAccounts();
        
        Account account = accounts.Find(account => account.AccountName == accountName);
        string accountPrivateKey = account.SecretKey;

        return Base32Encoding.ToBytes(accountPrivateKey);
    }
}
