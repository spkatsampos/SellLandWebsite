using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
//Reference: http: //stackoverflow.com/questions/3984138/hash-string-in-c-sharp/6839784
public class Security
{
    public static string HashSHA1(string value)
    {
        var sha1 = System.Security.Cryptography.SHA1.Create();
        var inputBytes = Encoding.ASCII.GetBytes(value);
        var hash = sha1.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}