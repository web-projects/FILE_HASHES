using System.Data.HashFunction;

namespace CRCHash.Hashes.Blake
{
    public static class BlakeHasher
    {
        public static byte[] GetHashValue(byte[] hashValue)
        {
            Blake2B blake2B = new Blake2B();
            byte[] hashBytes = blake2B.ComputeHash(hashValue);
            //return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hashBytes;
        }
    }
}
