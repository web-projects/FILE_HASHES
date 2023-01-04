using Microsoft.IO;
using System;
using System.Data.HashFunction.xxHash;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CheckSum.Hashes
{
    public static class HashingUtilities
    {
        static private int MakeItHex(int value)
        {
            int result = value;

            // 0-1 : 0x30-0x39
            // a-f : 0x61-0x66
            // A-F : 0x41-0x46

            if (result > 0x39)
            {
                if (result > 0x60)
                {
                    result -= 0x57;
                }
                else
                {
                    result -= 0x37;
                }
            }
            else
            {
                result -= 0x30;
            }

            return result;
        }

        public static string ComputeCrc32Hash(byte[] data)
        {
            byte[] bytes = Crc32.ComputeChecksumBytes(data);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static string ComputeCrc64Hash(byte[] data)
        {
            Crc64Iso crc = new Crc64Iso();

            byte[] bytes = crc.ComputeHash(data);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static string ComputeSHA256Hash(string data)
        {
            using (SHA256 shaHash = SHA256.Create())
            {
                byte[] bytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static string ComputeMD5FromFileStream(FileStream stream)
        {
            using (var md5 = MD5.Create())
            {
                return Convert.ToBase64String(md5.ComputeHash(stream));
            }
        }

        public static string ComputeMD5FromByteArray(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                // unable to decrypt
                if (data == null)
                {
                    return string.Empty;
                }

                RecyclableMemoryStreamManager streamManager = new RecyclableMemoryStreamManager();
                MemoryStream ms = streamManager.GetStream(data);
                return Convert.ToBase64String(md5.ComputeHash(ms));
            }
        }

        public static string ComputeXXHashFromFileStream(FileStream stream)
        {
            IxxHash xxHash = xxHashFactory.Instance.Create(new xxHashConfig()
            {
                HashSizeInBits = 64
            });

            return xxHash.ComputeHash(stream).AsHexString();
        }
    }
}
