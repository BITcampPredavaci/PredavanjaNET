using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D04_Toolbox
{
    class CampMath
    {
        /// <summary>
        /// Calculates the power b^pow for integers
        /// </summary>
        /// <param name="b">base value</param>
        /// <param name="pow">power value</param>
        /// <returns>b to the power pow</returns>
        public static double Pow(int b, int pow)
        {
            bool isNegative = pow < 0;
            pow = Math.Abs(pow);
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= b;
            }

            if (isNegative == true)
            {
                result = 1 / result;
            }
            return result;
        }
    }
}
