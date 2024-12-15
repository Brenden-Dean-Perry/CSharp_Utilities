using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities.Classes
{
    public static class Hash
    {
        /// <summary>
        /// Returns hash of string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static byte[] GetHash(string inputString, HashAlgo algo = HashAlgo.Shannon256)
        {
            switch (algo)
            {
                case (HashAlgo.Shannon256):
                    return GetHash_SHA256(inputString);
                case (HashAlgo.Shannon384):
                    return GetHash_SHA384(inputString);
                case (HashAlgo.Shannon512):
                    return GetHash_SHA512(inputString);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns hash of string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static byte[] GetHash_SHA256(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        /// <summary>
        /// Returns hash of string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static byte[] GetHash_SHA384(string inputString)
        {
            using (HashAlgorithm algorithm = SHA384.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        /// <summary>
        ///  Returns hash of string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static byte[] GetHash_SHA512(string inputString)
        {
            using (HashAlgorithm algorithm = SHA512.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        /// <summary>
        /// Effeciently returns the resulting hash as a string using a selected hashing method passed as a parameter.
        /// </summary>
        /// <param name="inputString">String to hash.</param>
        /// <param name="GetHash">Method to execute the hashing.</param>
        /// <returns></returns>
        public static string GetHashString(string inputString, Func<string, string> GetHash)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
