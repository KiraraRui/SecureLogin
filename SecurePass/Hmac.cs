using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurePass
{
    public enum Hmactypes
    {
        HMACSHA1 = 0, SHA256 = 1, SHA384 = 2, SHA512 = 4
    }

    public class Hmac
    {

        private readonly HMAC _hmac;


        //when doin new hmac it goes through the ctor
        public Hmac(Hmactypes type)
        {

            if (type == Hmactypes.HMACSHA1)
            {
                _hmac = new HMACSHA1();
            }

            if (type == Hmactypes.SHA256)
            {
                _hmac = new HMACSHA256();
            }

            if (type == Hmactypes.SHA384)
            {
                _hmac = new HMACSHA384();
            }

            if (type == Hmactypes.SHA512)
            {
                _hmac = new HMACSHA512();
            }

        }
        //compute hmac method
        public byte[] HmacAlgorithm(string message, string key)
        {
            //gets bytes of message string
            byte[] messagebytes = Encoding.UTF8.GetBytes(message);
            //gets bytes of key string
            byte[] keybytes = Encoding.UTF8.GetBytes(key);


            _hmac.Key = keybytes;
            //compute hash
            return _hmac.ComputeHash(messagebytes);


        }

        public bool Validate(string message, string key, string hash)
        {
            //gets bytes of message string
            byte[] messagebytes = Encoding.UTF8.GetBytes(message);
            //gets bytes of key string
            byte[] keybytes = Encoding.UTF8.GetBytes(key);
            //gets bytes of hash string
            byte[] hashbytes = Convert.FromBase64String(hash);

            _hmac.Key = keybytes;

            if (CompareByteArray(_hmac.ComputeHash(messagebytes), hashbytes, _hmac.HashSize / 8))
            {
                return true;

            }
            return false;
        }

        //This method compares 2 byte arrays 
        private bool CompareByteArray(byte[] a, byte[] b, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

