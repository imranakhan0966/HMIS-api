using System.Security.Cryptography;
using System.Text;

namespace HMIS.Common
{
    public class DecryptConnectionHelper
    {
        //public string AESDecryptData(string data, int BlockSize, string Key, byte[] IV)
        //{
        //    byte[] decryptedBytes = null;
        //    byte[] bytes = Convert.FromBase64String(data);
        //    SymmetricAlgorithm crypt = Aes.Create();
        //    HashAlgorithm hash = MD5.Create();
        //    crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(Key));
        //    crypt.IV = IV;

        //    using (MemoryStream memoryStream = new MemoryStream(bytes))
        //    {
        //        using (CryptoStream cryptoStream =
        //           new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
        //        {
        //            decryptedBytes = new byte[bytes.Length];
        //            cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);

        //        }
        //    }
        //    var dataq = Encoding.Unicode.GetString(decryptedBytes);
        //    return Encoding.Unicode.GetString(decryptedBytes);
        //}

        public string AESDecryptData(string cipherText, string passPhrase,int Keysize, int DerivationIterations)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = Aes.Create())
                {
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                using (var plainTextStream = new MemoryStream())
                                {
                                    cryptoStream.CopyTo(plainTextStream);
                                    var plainTextBytes = plainTextStream.ToArray();
                                    //Console.WriteLine(Encoding.UTF8.GetString(plainTextBytes, 0, plainTextBytes.Length));
                                    return (Encoding.UTF8.GetString(plainTextBytes, 0, plainTextBytes.Length));
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
