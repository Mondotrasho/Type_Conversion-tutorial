using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RomanNumeral
{
    private int value;
    public RomanNumeral(int value)
    {
        this.value = value;
    }
    // Declare a conversion from an int to a RomanNumeral. Note the
    // the use of the operator keyword. This is a conversion
    // operator named RomanNumeral:
    static public implicit operator RomanNumeral(int value)
    {
        // Note that because RomanNumeral is declared as a struct,
        // calling new on the struct merely calls the constructor
        // rather than allocating an object on the heap:
        return new RomanNumeral(value);
    }
    // Declare an explicit conversion from a RomanNumeral to an int:
    static public explicit operator int(RomanNumeral roman)
    {
        return roman.value;
    }
    // Declare an implicit conversion from a RomanNumeral to
    // a string:
    static public implicit operator string(RomanNumeral roman)
    {
        Dictionary<string, int> RomantoNumeral = new Dictionary<string, int>();
        RomantoNumeral.Add("I", 1);
        RomantoNumeral.Add("IV", 4);
        RomantoNumeral.Add("V", 5);
        RomantoNumeral.Add("IX", 9);
        RomantoNumeral.Add("X", 10);
        RomantoNumeral.Add("XL", 40);
        RomantoNumeral.Add("L", 50);
        RomantoNumeral.Add("XC", 90);
        RomantoNumeral.Add("C", 100);
        RomantoNumeral.Add("CD", 400);
        RomantoNumeral.Add("D", 500);
        RomantoNumeral.Add("CM", 900);
        RomantoNumeral.Add("M", 1000);
        Dictionary<int, string> NumeraltoRoman = new Dictionary<int, string>();
        NumeraltoRoman.Add(1, "I");
        NumeraltoRoman.Add(2, "II");
        NumeraltoRoman.Add(3, "III");
        NumeraltoRoman.Add(4, "IV");
        NumeraltoRoman.Add(5, "V");
        NumeraltoRoman.Add(6, "VI");
        NumeraltoRoman.Add(7, "VII");
        NumeraltoRoman.Add(8, "VIII");
        NumeraltoRoman.Add(9, "IX");
        NumeraltoRoman.Add(10, "X");
        NumeraltoRoman.Add(40, "XL");
        NumeraltoRoman.Add(50, "L");
        NumeraltoRoman.Add(90, "XC");
        NumeraltoRoman.Add(100, "C");
        NumeraltoRoman.Add(400, "CD");
        NumeraltoRoman.Add(500, "D");
        NumeraltoRoman.Add(900, "CM");
        NumeraltoRoman.Add(1000, "M");

        int[] int_array = digitArr2(roman.value);

        if (numDigits(roman.value) == 2)
        {
            int_array[0] *= 10;
        }

        if (numDigits(roman.value) == 3)
        {
           int_array[0] *= 100;
            int_array[1] *= 10;
        }
        // make the string builder to patch things together
        StringBuilder myStringBuilder = new StringBuilder();
        for (int i = 0; i < int_array.Length; i++)
        {

            string outputstring = "";
            

            if (NumeraltoRoman.TryGetValue(int_array[i], out outputstring))
            {
                myStringBuilder.Append(outputstring);
                continue;
            }

            else
            {
                
                var outputtimesme = "";
                var digits = numDigits(int_array[i]);
                if (digits == 2)
                {
                    if (int_array[i] > 50)
                    {
                        var tasd = "";
                        NumeraltoRoman.TryGetValue(50, out tasd);
                        {
                            myStringBuilder.Append(tasd);
                        }

                        int_array[i] = int_array[i] - 50;
                    }
                    var throwaway = (int_array[i] / (int_array[i] / 10));
                    if (NumeraltoRoman.TryGetValue(throwaway, out outputtimesme))
                    {
                        for (int j = 0; j <= int_array[i] / int_array[i]; j++)
                        {
                            myStringBuilder.Append(outputtimesme);
                        }
                    }
                }

                if (digits == 3)
                {
                    if (int_array[i] > 500)
                    {
                        var tasd = "";
                        NumeraltoRoman.TryGetValue(500, out tasd);
                        {
                        myStringBuilder.Append(tasd);
                        }

                        int_array[i] = int_array[i] - 500;
                    }
                    var throwaway3 = (int_array[i] / (int_array[i] / 10));
                    throwaway3 *= 10;
                    if (NumeraltoRoman.TryGetValue(throwaway3, out outputtimesme))
                    {
                        for (int j = 0; j <= int_array[i] / int_array[i]; j++)
                        {
                            myStringBuilder.Append(outputtimesme);
                        }
                    }
                }

            }

        }

        return myStringBuilder.ToString();


    }
    public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(IDictionary<TKey, TValue> source)
    {
        var dictionary = new Dictionary<TValue, TKey>();
        foreach (var entry in source)
        {
            if (!dictionary.ContainsKey(entry.Value))
                dictionary.Add(entry.Value, entry.Key);
        }
        return dictionary;
    }
    public static int numDigits(int n)
    {
        if (n < 0)
        {
            n = (n == Int32.MinValue) ? Int32.MaxValue : -n;
        }
        if (n < 10) return 1;
        if (n < 100) return 2;
        if (n < 1000) return 3;
        if (n < 10000) return 4;
        if (n < 100000) return 5;
        if (n < 1000000) return 6;
        if (n < 10000000) return 7;
        if (n < 100000000) return 8;
        if (n < 1000000000) return 9;
        return 10;
    }

    public static int[] digitArr2(int n)
    {
        var result = new int[numDigits(n)];
        for (int i = result.Length - 1; i >= 0; i--)
        {
            result[i] = n % 10;
            n /= 10;
        }
        return result;
    }
}