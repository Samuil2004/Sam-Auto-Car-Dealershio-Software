using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// This class provides methods for creating salts and generating SHA-256 hashes for password masking.
    /// </summary>
    public class PasswordMaskingManager
    {

        /// <summary>
        /// Creates a salt of a specified size.
        /// </summary>
        /// <param name="sizeOfSalt">The size of the salt to create, in characters.</param>
        /// <returns>A string representing the generated salt.</returns>
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


        /// <summary>
        /// Generates a SHA-256 hash of the input password combined with the provided salt.
        /// </summary>
        /// <param name="inputtedPassword">The password to hash.</param>
        /// <param name="salt">The salt to append to the password before hashing.</param>
        /// <returns>A base64 string representing the hashed password.</returns>
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
