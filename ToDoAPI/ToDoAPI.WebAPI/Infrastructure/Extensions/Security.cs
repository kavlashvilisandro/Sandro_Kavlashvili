using System.Security.Cryptography;
using System.Text;


namespace ToDoAPI.WebAPI.Infrastructure.Extensions
{
    public static class Security
    {
        public static string HashString(this string input)
        {
            using (SHA512 sha256 = SHA512.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
