using System;
using System.Security.Cryptography;

namespace CRCHash.Hashes.MD5
{
    public static class MD5
    {
        public static byte[] GetHash16Bytes(string hash32)
        {
            byte[] hash16 = new byte[16];

            for (int i = 0; i < 32; i += 2)
            {
                uint high = Convert.ToUInt32(hash32[i]);
                uint low = Convert.ToUInt32(hash32[i + 1]);
                char c = (char)((high << 4) | low);

                hash16[i] = (byte)c;
            }

            return hash16;
        }

        public static string GetHash16(string hash32)
        {
            string hash16 = string.Empty;

            for (int i = 0; i < 32; i += 2)
            {
                uint high = Convert.ToUInt32(hash32[i]);
                uint low = Convert.ToUInt32(hash32[i + 1]);
                char c = (char)((high << 4) | low);

                hash16 += c;
            }

            return hash16;
        }

        public static byte[] ComputeMD5Hash(byte[] input)
        {
            return new MD5CryptoServiceProvider().ComputeHash(input);
        }
    }
}
