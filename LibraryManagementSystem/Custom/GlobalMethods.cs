using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Custom
{
    public static class GlobalMethods
    {
        public static MainWindow main;

        private static string ComputeSha256Hash(this string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string returnUserPassword(string userPw,string randomString)
        {
            return ComputeSha256Hash(userPw + randomString);
        }

        public static string returnUserIp()
        {
            return "152.34.64.123";
        }

    }


    static public class DateTimeHelper
    {
        public static DateTime ServerTime
        {
            get { return DateTime.UtcNow; }
        }
    }



}
