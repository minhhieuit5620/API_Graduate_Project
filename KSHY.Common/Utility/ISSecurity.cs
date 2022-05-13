using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ISCommon.Utility
{
    public static class ISSecurity
    {
        public static string MD5Hash(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static string HashCalculate(string str)
        {
            MD5 md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(str);
            var hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
        public static string EncryptASCII(string text, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = ASCIIEncoding.ASCII.GetBytes(text);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            }
            else keyArray = ASCIIEncoding.ASCII.GetBytes(key);
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptASCII(string text, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(text);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            }
            else keyArray = ASCIIEncoding.ASCII.GetBytes(key);
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return ASCIIEncoding.ASCII.GetString(resultArray);
        }

        public static string EncryptUTF8(string toEncrypt, string key, bool useHashing = true)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        
        public static string DecryptUTF8(string toDecrypt, string key, bool useHashing = true)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        public static string EncryptURL(string toEncrypt, string key, bool useHashing = true)
        {
            if (string.IsNullOrEmpty(toEncrypt))
            {
                return string.Empty;
            }

            return EncryptUTF8(toEncrypt, key, useHashing).Replace('+', '-').Replace('/', '_').Replace('=', '.');
        }

        public static string DecryptURL(string toDecrypt, string key, bool useHashing = true)
        {
            if (string.IsNullOrEmpty(toDecrypt))
            {
                return string.Empty;
            }

            return DecryptUTF8(toDecrypt.Replace("-", "+").Replace("_", "/").Replace('.', '='), key, useHashing);
        }

        public static string Rand8(int? length = null)
        {
            int w_length = 0;
            if (length == null)
            {
                w_length = 8;
            }
            else
            {
                w_length = length.Value;
            }
          
            //  48-57,65-90,97-122
            int upperbound = 122;
            int lowerbound = 48;
            Random rnd = new Random();

            int i = 1;

            string w_text = "";
            while(i <= w_length){
                int w_rnd = rnd.Next(lowerbound, upperbound);
                if ((w_rnd > 57 && w_rnd < 65) || (w_rnd > 90 && w_rnd < 97)) { }
                else{
                     char charData;
                     charData = (char)w_rnd;
                     w_text += charData.ToString();
                     i++;
                }
            }
            
            return w_text;
        }
      
        public static int OpenLogic(string path, string fileName, out Dictionary<string, object> data)
        {
            data = new Dictionary<string, object>();
            string[] result = null;
            int code = ISFile.ISOpenLines(path, fileName, out result);
            if (code == 1)
            {
                foreach (string item in result)
                {
                    if (!string.IsNullOrEmpty(item) && item.IndexOf("=") > 0)
                    {
                        string[] value = item.Split('=');
                        if (value.Length == 2)
                        {
                            data.Add(value[0], value[1]);
                        }
                    }
                }
            }
            return 1;
        }

        public static string RamdonStringForSalt()
        {
            var random = new RNGCryptoServiceProvider();
            int max_length = 32;
            byte[] salt = new byte[max_length];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }
        public static string HashSHA256(string value)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        public static int NumberCalculate(int min, int max)
        {
            Random rd = new Random();
            int randNum = rd.Next(min, max + 1); //Lấy cả min và cả max
            return randNum;
        }
        public static string StringCalculate(int limit)
        {
            if (limit <= 0)
            {
                limit = 10;
            }

            Random rd = new Random();

            var text = "abcdefghijklmnopqrstuvwxyz";
            var firstText = text[rd.Next(text.Length)];
            var possible = "abcdefghijklmnopqrstuvwxyz0123456789";

            string randomText = firstText.ToString();

            for (int i = 0; i < limit - 1; i++)
            {
                randomText += possible[rd.Next(possible.Length)].ToString();
            }

            return randomText;
        }
       
    }
}

