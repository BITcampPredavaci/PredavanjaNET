using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10D02_Streams
{
    class CryptUtil
    {

        private static int _ALPHABETLENGTH = 26;

        private static char ShiftChar(char c, int shift)
        {
           

            if (c == ' ' || c == '.')
                return c;
            if(c >= '0' && c <= '9')
                return c;

            
            int charAsInt = 0;
            if (c >= 'A' && c <= 'Z')
                charAsInt = (c + shift) % (_ALPHABETLENGTH + 'A');
            else
                charAsInt = (c + shift) % (_ALPHABETLENGTH + 'a');

            return (char)charAsInt;
        }


        public static string Encrypt(string src, int shift)
        {
            
            StringBuilder sb = new StringBuilder();

            foreach (char el in src) {
                sb.Append(ShiftChar(el, shift));
            }
            return sb.ToString();
        }


        public static string Decrypt(string src, int shift)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char el in src) {
                sb.Append(ShiftChar(el, shift));
            }
            return sb.ToString();
        }

        private static bool IsValidString(string src)
        {
                foreach(char c in src){
                    if (c < '0' && c != ' ' && c != '.')
                        return false;
                    if (c > '9' && c < 'A')
                        return false;
                    if (c > 'Z' && c < 'a')
                        return false;
                    if (c > 'z')
                        return false;
                }

                return true;
        }

        public static List<string> BruteForce(string src)
        {
            List<string> results = new List<string>();
            for (int i = -26; i <= 26; i++) {
                string candidate = Decrypt(src, i);
                if (IsValidString(candidate)) {
                    results.Add(candidate);
                }
            }

            return results;
        }


    }
}
