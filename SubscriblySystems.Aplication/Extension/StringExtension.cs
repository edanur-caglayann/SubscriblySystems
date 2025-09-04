using System.Security.Cryptography;
using System.Text;

namespace SubscriblySystems.Aplication.Extension;

public static class StringExtension
{
    public static string ComputeSha256Hash(this string rawData)
    {
        using var sha256Hash = SHA256.Create();

        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        var builder = new StringBuilder();

        for (var i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();
    }  
}