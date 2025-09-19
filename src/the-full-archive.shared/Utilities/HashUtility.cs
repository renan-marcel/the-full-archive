using System.Security.Cryptography;
using System.Text;

namespace TheFullArchive.shared.Utilities;

public static class HashUtility
{
    public static async Task<string> CalculateSha256HashAsync(Stream stream)
    {
        using var sha256 = SHA256.Create();
        var hashBytes = await sha256.ComputeHashAsync(stream);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
}
