using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class Sha1
    {
        public static string getSha1String(string str)
        {
            var enc = Encoding.UTF8;

            byte[] buffer = enc.GetBytes(str);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
    }
}
