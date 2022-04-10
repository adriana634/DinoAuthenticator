namespace DinoAuthenticator.AccountsTotp;

public readonly record struct Account(string AccountName, string SecretKey);