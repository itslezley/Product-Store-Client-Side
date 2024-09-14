using System.Security.Cryptography;
using System.Text;

namespace Lezlab.Business
{
    public class HashPass
    {

        //Hashing Method
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedPasswordBytes);
            }
        }

    }
}
