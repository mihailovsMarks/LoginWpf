using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncDec
{
    class AesCrypt
    {
        public static string IV = "hdngriad82xolajd";
        public static string Key = "hfkeor85hgncldp1028fy374hfnc93ir";

        //Encryption
        public static string Encrypt(string Decrypt)
        {
            byte[] textbyte = ASCIIEncoding.ASCII.GetBytes(Decrypt);
            AesCryptoServiceProvider ecdc = new AesCryptoServiceProvider();

            ecdc.BlockSize = 128;
            ecdc.KeySize = 256;
            ecdc.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            ecdc.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            ecdc.Padding = PaddingMode.PKCS7;
            ecdc.Mode = CipherMode.CBC;

            ICryptoTransform crypto = ecdc.CreateEncryptor(ecdc.Key, ecdc.IV);

            byte[] ec = crypto.TransformFinalBlock(textbyte, 0, textbyte.Length);
            crypto.Dispose();

            return Convert.ToBase64String(ec);
        }

        //Decryption
        public static string Decrypt(string Encrypt)
        {
            byte[] ecbyte = Convert.FromBase64String(Encrypt);
            AesCryptoServiceProvider ecdc = new AesCryptoServiceProvider();

            ecdc.BlockSize = 128;
            ecdc.KeySize = 256;
            ecdc.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            ecdc.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            ecdc.Padding = PaddingMode.PKCS7;
            ecdc.Mode = CipherMode.CBC;

            ICryptoTransform crypto = ecdc.CreateDecryptor(ecdc.Key, ecdc.IV);

            byte[] dc = crypto.TransformFinalBlock(ecbyte, 0, ecbyte.Length);
            crypto.Dispose();

            return ASCIIEncoding.ASCII.GetString(dc);
        }
    }
}
