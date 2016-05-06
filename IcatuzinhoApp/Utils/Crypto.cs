using System;
using System.Text;
using PCLCrypto;

namespace IcatuzinhoApp
{
    public static class Crypto
    {
        public static string EncryptStringAES(string info, string sharedSecret)
        {
            byte[] keyMaterial = Encoding.UTF8.GetBytes(sharedSecret);
            byte[] data = Encoding.UTF8.GetBytes(info);

            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);

            byte[] iv = Encoding.UTF8.GetBytes(Constants.SharedSecret);
            byte[] cipherText = WinRTCrypto.CryptographicEngine.Encrypt(key, data, iv);

            return Encoding.UTF8.GetString(cipherText, 0, cipherText.Length);

            //byte[] plainText = WinRTCrypto.CryptographicEngine.Decrypt(key, cipherText, iv);
        }
    }
}
