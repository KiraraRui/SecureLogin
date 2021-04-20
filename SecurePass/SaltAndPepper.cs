using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass
{
    class SaltAndPepper
    {
        public string Shaker(string plainText, Hash hashAlgorithm, byte[] saltBytes)
        {
           
            // If salt is not specified, generate it.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                //--------use the HasHer----------

                // Fill the salt with cryptographically strong byte values.
                //rng.GetNonZeroBytes(saltBytes);

            }
            return "";
        }
    }
}
