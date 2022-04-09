namespace DinoAuthenticator;

internal readonly record struct ComputedTotp(string TotpCode, int InitialRemainingTotpSeconds);