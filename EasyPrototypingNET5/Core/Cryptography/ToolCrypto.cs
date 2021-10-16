//-----------------------------------------------------------------------
// <copyright file="ToolCrypto.cs" company="PTA">
//     Class: ToolCrypto
//     Copyright © PTA GmbH 2016
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@contractors.roche.com</email>
// <date>1.1.2016</date>
//
// <summary>Class with Cryptography Functions</summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Core
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class ToolCrypto
    {
        private static readonly byte[] internalKey = { 0x16, 0x15, 0x14, 0x13, 0x11, 0x10, 0x09, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        private static readonly byte[] internalVector = { 0x16, 0x15, 0x14, 0x13, 0x11, 0x10, 0x09, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        public static string Decrypt(string pInputString)
        {
            string outputString = string.Empty;

            if (string.IsNullOrEmpty(pInputString) == true)
            {
                return string.Empty;
            }

            try
            {
                using (MemoryStream inStream = new MemoryStream())
                {
                    byte[] inBytes = Convert.FromBase64String(pInputString);
                    inStream.Write(inBytes, 0, inBytes.Length);
                    inStream.Position = 0;

                    MemoryStream outStream = new MemoryStream();
                    byte[] buffer = new byte[128];

                    SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create("Rijndael");
                    algorithm.IV = internalVector;
                    algorithm.Key = internalKey;
                    ICryptoTransform transform = algorithm.CreateDecryptor();
                    CryptoStream cryptedStream = new CryptoStream(inStream, transform, CryptoStreamMode.Read);

                    int restLength = cryptedStream.Read(buffer, 0, buffer.Length);
                    while (restLength > 0)
                    {
                        outStream.Write(buffer, 0, restLength);
                        restLength = cryptedStream.Read(buffer, 0, buffer.Length);
                    }

                    outputString = System.Text.Encoding.Default.GetString(outStream.ToArray());

                    cryptedStream.Close();
                    cryptedStream = null;
                    inStream.Close();
                    outStream.Close();
                    outStream = null;
                }

                return outputString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Encrypt(string pInputString)
        {
            string outputString = string.Empty;

            if (string.IsNullOrEmpty(pInputString) == true)
            {
                return string.Empty;
            }

            try
            {
                using (MemoryStream inStream = new MemoryStream())
                {
                    byte[] inBytes = new byte[pInputString.Length];
                    inBytes = System.Text.Encoding.Default.GetBytes(pInputString);
                    inStream.Write(inBytes, 0, inBytes.Length);
                    inStream.Position = 0;

                    MemoryStream outStream = new MemoryStream();
                    byte[] buffer = new byte[128];

                    SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create("Rijndael");
                    algorithm.IV = internalVector;
                    algorithm.Key = internalKey;
                    ICryptoTransform transform = algorithm.CreateEncryptor();
                    CryptoStream cryptedStream = new CryptoStream(outStream, transform, CryptoStreamMode.Write);

                    int restLength = inStream.Read(buffer, 0, buffer.Length);
                    while (restLength > 0)
                    {
                        cryptedStream.Write(buffer, 0, restLength);
                        restLength = inStream.Read(buffer, 0, buffer.Length);
                    }

                    cryptedStream.FlushFinalBlock();

                    outputString = System.Convert.ToBase64String(outStream.ToArray());

                    cryptedStream.Close();
                    cryptedStream = null;
                    inStream.Close();
                    outStream.Close();
                    outStream = null;
                }

                return outputString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string HashFileMD5(string pFileName)
        {
            if (File.Exists(pFileName) == true)
            {
                using (var md5 = MD5.Create())
                {
                    return BitConverter.ToString(md5.ComputeHash(File.ReadAllBytes(pFileName))).Replace("-", string.Empty);
                }
            }

            return string.Empty;
        }

        public static string HashStringMD5(string text, bool withSeparator = false)
        {
            string result = string.Empty; 
            using (var md5 = MD5.Create())
            {
                byte[] inputByte = StringToByteArray(text);
                if (withSeparator == true)
                {
                    result = BitConverter.ToString(md5.ComputeHash(inputByte));
                }
                else
                {
                    result = BitConverter.ToString(md5.ComputeHash(inputByte)).Replace("-", string.Empty);
                }
            }

            return result;
        }

        public static byte[] GetRandomData(int length)
        {
            length = length.IsArgumentOutOfRange("length", length == 0);

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return StringToByteArray(res.ToString());
        }

        private static byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }

        private static string ByteArrayToString(byte[] arr)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(arr);
        }
    }
}
