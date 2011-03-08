using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class MPHash
    {
        public static string hash(string sPassword)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPassword);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }


            byte[] bs1 = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            bs1 = x.ComputeHash(bs1);
            System.Text.StringBuilder s1 = new System.Text.StringBuilder();
            foreach (byte bc in bs1)
            {
                s1.Append(bc.ToString("x2").ToLower());
            }


            return s.ToString() + s1.ToString();
        }
        public static string Hash10(string hash)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs1 = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString()+hash);
            bs1 = x.ComputeHash(bs1);
            System.Text.StringBuilder s1 = new System.Text.StringBuilder();
            foreach (byte bc in bs1)
            {
                s1.Append(bc.ToString("x2").ToLower());
            }
            return s1.ToString();
        }

        public static string GetRandomPassword(int numChars, int seed)
        {
            string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S","T", "U", "V", "W", "X", "Y", "Z", "2", "3", "4", "5", "6", "7", "8", "9"};

            Random rnd = new Random(seed);
            string random = string.Empty;
            for (int i = 0; i < numChars; i++)
            {
                random += chars[rnd.Next(0, 33)];
            }
            return DateTime.Now.Second.ToString()+random;
        }

        public static string GetPassWordMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }
    }
}