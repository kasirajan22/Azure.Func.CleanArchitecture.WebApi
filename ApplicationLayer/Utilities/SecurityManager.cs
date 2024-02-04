using CryptoHelper;

namespace ApplicationLayer;

/// <summary>
/// https://github.com/henkmollema/CryptoHelper
/// Standalone password hasher for ASP.NET Core using a PBKDF2 implementation.
/// </summary>
public class SecurityManager
{
    public static string HashPassword(string password)
    {
        return Crypto.HashPassword(password);
    }

    public static bool VerifyPassword(string hash, string password)
    {
        return Crypto.VerifyHashedPassword(hash, password);
    }

    public static string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new();
        char[] chars = new char[PasswordLength];
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
}
