using System.Security.Cryptography;
using System.Text;

namespace SecurePass
{
    public class Hash
    {

        //creates our hashing as well as "returns it as byte"
        public byte[] ComputeHashSha1(string toBeHashed)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(toBeHashed);
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(messageBytes);
            }
        }

        public byte[] ComputeHashSha256(string toBeHashed)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(toBeHashed);
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(messageBytes);
            }
        }

        public byte[] ComputeHashSha384(string toBeHashed)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(toBeHashed);
            using (SHA384 sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(messageBytes);
            }
        }

        public byte[] ComputeHashSha512(string toBeHashed)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(toBeHashed);
            using (SHA512 sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(messageBytes);
            }
        }
    }
}
