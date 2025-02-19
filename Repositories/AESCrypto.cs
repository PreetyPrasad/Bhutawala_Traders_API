using System.Security.Cryptography;
using System.Text;

namespace Bhutawala_Traders_API.Repositories
{
    public class AESCrypto
    {
        private static readonly string Key = "w2vHqL1M8z9J2Xf+UdYYN7j6LW7OW3q9"; // Base64-encoded key (32 bytes)
        private static readonly string IV = "F4F1uQZxO5NLc2Z5V9hvUw=="; // Base64-encoded IV (16 bytes)

        public string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(Key); // ✅ Decode Base64 key
                aesAlg.IV = Convert.FromBase64String(IV);   // ✅ Decode Base64 IV
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(Key); // ✅ Decode Base64 key
                aesAlg.IV = Convert.FromBase64String(IV);   // ✅ Decode Base64 IV
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

    }
}
