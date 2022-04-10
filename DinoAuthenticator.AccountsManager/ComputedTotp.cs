namespace DinoAuthenticator.AccountsTotp;

public readonly record struct ComputedTotp(string TotpCode, int InitialRemainingTotpSeconds);