using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Utilities.Enums;

namespace Utilities.Classes
{
    public class RSAEncryption
    {
        private RSAParameters _sharedParameters { get; set; }
        public RSAEncryption()
        {}

        public void GenerateKeys()
        {
            using (RSA rsa = RSA.Create())
            {
                _sharedParameters = rsa.ExportParameters(true);
            }
        }

        public byte[] GetSignedHash(byte[] hash, HashAlgo algo = HashAlgo.Shannon256)
        {
            byte[] signedHash;
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(_sharedParameters);
                RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
                string algoName = algo.StringValueOf();
                rsaFormatter.SetHashAlgorithm(algoName);
                signedHash = rsaFormatter.CreateSignature(hash);
            }
            return signedHash;
        }

        public bool VerifySignature(byte[] hash, byte[] signedHash, HashAlgo algo = HashAlgo.Shannon256)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(_sharedParameters);
                RSAPKCS1SignatureDeformatter rsaDeformatter = new(rsa);
                string algoName = algo.StringValueOf();
                rsaDeformatter.SetHashAlgorithm(algoName);
                return rsaDeformatter.VerifySignature(hash, signedHash);
            }
        }
    }
}
