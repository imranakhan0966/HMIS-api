using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Common.Helpers
{
    public class EncryptionHelper
    {




        public static string EncryptForPassword(string password, byte[] salt, byte[] IV)
        {
            try
            {
                if (password == string.Empty)
                    return string.Empty;

                System.Security.Cryptography.TripleDESCryptoServiceProvider des = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                des.IV = IV;
                System.Security.Cryptography.PasswordDeriveBytes pdb = new System.Security.Cryptography.PasswordDeriveBytes(password, salt);
                des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, IV);
                MemoryStream ms = new MemoryStream(password.Length * 2 - 1);
                System.Security.Cryptography.CryptoStream encStream = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                byte[] plainBytes = Encoding.UTF8.GetBytes(password);
                encStream.Write(plainBytes, 0, plainBytes.Length);
                encStream.FlushFinalBlock();
                byte[] encryptedBytes = new byte[Convert.ToInt32(ms.Length - 1) + 1];
                ms.Position = 0;
                ms.Read(encryptedBytes, 0, Convert.ToInt32(ms.Length));
                encStream.Close();

                return Convert.ToBase64String(encryptedBytes);
            }

            // Return value
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
