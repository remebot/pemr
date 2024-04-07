using System.Security.Cryptography;
using System.Text;

namespace Iben.PEMR.Api.Utils;

/// <summary>
/// AES加密算法工具类。
/// </summary>
public static class AesUtils
{
    /// <summary>
    /// 加密。
    /// </summary>
    /// <param name="plainText">明文。</param>
    /// <param name="key">加密密钥。</param>
    /// <param name="iv">偏移量。</param>
    /// <returns>加密数据。</returns>
    public static string Encrypt(string plainText, string key, string iv)
    {
        byte[] bKey = Encoding.UTF8.GetBytes(key);
        byte[] bIv = Encoding.UTF8.GetBytes(iv);

        using var aesAlg = Aes.Create();
        aesAlg.Mode = CipherMode.CBC;
        aesAlg.Padding = PaddingMode.PKCS7;
        using var encryptor = aesAlg.CreateEncryptor(bKey, bIv);

        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write, true))
        using (var swEncrypt = new StreamWriter(csEncrypt, leaveOpen: true))
        {
            swEncrypt.Write(plainText);
        }

        byte[] decryptedContent = msEncrypt.ToArray();

        return Convert.ToHexString(decryptedContent);
    }

    /// <summary>
    /// 解密。
    /// </summary>
    /// <param name="cipherHex">加密的十六进制文本。</param>
    /// <param name="key">加密密钥。</param>
    /// <param name="iv">偏移量。</param>
    /// <returns>解密数据。</returns>
    public static string Decrypt(string cipherHex, string key, string iv)
    {
        byte[] fullCipher = Convert.FromHexString(cipherHex);

        byte[] bKey = Encoding.UTF8.GetBytes(key);
        byte[] bIv = Encoding.UTF8.GetBytes(iv);

        using var aesAlg = Aes.Create();
        aesAlg.Mode = CipherMode.CBC;
        aesAlg.Padding = PaddingMode.PKCS7;
        using var decryptor = aesAlg.CreateDecryptor(bKey, bIv);
        using var msDecrypt = new MemoryStream(fullCipher);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }
}
