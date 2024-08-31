using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PasswordMaskingManager
    {
        public string CreateSalt(int sizeOfSalt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789./";
            while (0 < sizeOfSalt)
            {
                stringBuilder.Append(validCharacters[random.Next(validCharacters.Length)]);
                sizeOfSalt--;
            }
            return stringBuilder.ToString();
        }

        public string GenerateSHA256Hash(string inputtedPassword, string salt)
        {
            byte[]saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[]inputtedPasswordBytes = Encoding.UTF8.GetBytes(inputtedPassword);
            byte[]saltAndInputterPasswordBytes = new byte[saltBytes.Length + inputtedPasswordBytes.Length];

            Buffer.BlockCopy(saltBytes,0,saltAndInputterPasswordBytes,0,saltBytes.Length);
            Buffer.BlockCopy(inputtedPasswordBytes, 0, saltAndInputterPasswordBytes,saltBytes.Length,inputtedPassword.Length);

            using(var sha256 = SHA256.Create())
            {
                byte[]hashedByte = sha256.ComputeHash(saltAndInputterPasswordBytes);
                return Convert.ToBase64String(hashedByte); 
            }
        }
    }
}
