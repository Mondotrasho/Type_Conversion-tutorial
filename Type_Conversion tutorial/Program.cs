using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conversion_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            RomanNumeral numeral;
            numeral = 783;
            // Call the explicit conversion from numeral to int. Because it is
            // an explicit conversion, a cast must be used:
            Console.WriteLine((int)numeral);
            // Call the implicit conversion to string. Because there is no
            // cast, the implicit conversion to string is the only
            // conversion that is considered:
            Console.WriteLine(numeral);
            // Call the explicit conversion from numeral to int and
            // then the explicit conversion from int to short:
            short s = (short)numeral;
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
