using System.Security.Cryptography;

namespace DinoAuthenticator.AccountsTotp;

internal static class ProtectedAccountsData
{
    // Create byte array for additional entropy when using Protect method.
    private static readonly byte[] ENTROPY = { 9, 8, 7, 6, 5 };

    internal static byte[] ProtectBytes(byte[] data)
    {
        // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
        // only by the same current user.
        return ProtectedData.Protect(data, ProtectedAccountsData.ENTROPY, DataProtectionScope.CurrentUser);
    }

    internal static byte[] UnprotectBytes(byte[] data)
    {
        // Decrypt the data using DataProtectionScope.CurrentUser.
        return ProtectedData.Unprotect(data, ProtectedAccountsData.ENTROPY, DataProtectionScope.CurrentUser);
    }
}
