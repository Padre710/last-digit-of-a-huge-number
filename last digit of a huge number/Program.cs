using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.InteropServices;

//For a given list [x1, x2, x3, ..., xn] compute the last (decimal) digit of x1 ^ (x2 ^ (x3 ^ (... ^ xn))).

//E.g., with the input [3, 4, 2], your code should return 1 because 3 ^ (4 ^ 2) = 3 ^ 16 = 43046721.

//Beware: powers grow incredibly fast. For example, 9 ^ (9 ^ 9) has more than 369 millions of digits. 
//    lastDigit has to deal with such numbers efficiently.

//Corner cases: we assume that 0 ^ 0 = 1 and that lastDigit of an empty list equals to 1.

namespace last_digit_of_a_huge_number
{
    public class Calculator
    {
        public static int LastDigit(int[] array)
        {

            if (array == null)
            {
                return 0;
            }
            else if (array.Length == 0)
            {
                return 1;
            }
            else if (array.Length == 1)
            {

                string last = array[0].ToString();
                int myInt = int.Parse(last[last.Length - 1].ToString());
                return myInt;
            }


            else
            {
                if (array.Length == 2)
                {
                    return TwoLength(array[0], array[1]);
                }
                else
                 if ((array.Contains(0) || array.Contains(1)) && (array[0] != 0 && array[0] != 1))
                {
                    return zeroOne(array);
                }
                else
                {
                    return threelength(array);
                }

            }

        }
        public static int zeroOne(int[] array)
        {
            int i = 0;
            for (i = array.Length - 1; i > 0; i--)
            {
                if ((array[i]) == 0 || array[i] == 1)
                    break;
            }
            BigInteger a = (BigInteger)Math.Pow(array[i - 1], array[i]);
            List<int> ints = array.ToList();
            ints.RemoveRange(i - 1, ints.Count - (i - 1));
            ints.Add((int)a);

            return LastDigit(ints.ToArray());
        }
        public static int TwoLength(BigInteger n1, BigInteger n2)
        {
            string last = n1.ToString();
            int myInt = int.Parse(last[last.Length - 1].ToString());
            int y = (int)(n2 % 4);


            if (myInt == 0 && n2 != 0) { return 0; }
            else if (myInt == 1) { return 1; }
            else if (n2 == 0) { return 1; }
            else if (n2 == 1) { return myInt; }
            else if (myInt == 5 && n2 != 0) { return myInt; }
            else if (myInt == 6 && n2 != 0) { return myInt; }
            else
                return mod(myInt, y);


        }
        public static int mod(int n1, int n2)
        {
            if (n1 == 2)
            {
                if (n2 == 0)
                    return 6;
                else if (n2 == 1)
                    return 2;
                else if (n2 == 2)
                    return 4;
                else
                    return 8;
            }

            else if (n1 == 8)
            {
                if (n2 == 0)
                    return 6;
                else if (n2 == 1)
                    return 8;
                else if (n2 == 2)
                    return 4;
                else
                    return 2;
            }

            else if (n1 == 3)
            {
                if (n2 == 0)
                    return 1;
                else if (n2 == 1)
                    return 3;
                else if (n2 == 2)
                    return 9;
                else
                    return 7;
            }
            else if (n1 == 7)
            {
                if (n2 == 0)
                    return 1;
                else if (n2 == 1)
                    return 7;
                else if (n2 == 2)
                    return 9;
                else
                    return 3;
            }
            else if (n1 == 4)
            {
                if (n2 == 0)
                    return 6;
                else if (n2 == 1)
                    return 4;
                else if (n2 == 2)
                    return 6;
                else
                    return 4;

            }
            else
            {
                if (n2 == 0)
                    return 1;
                else if (n2 == 1)
                    return 9;
                else if (n2 == 2)
                    return 1;
                else
                    return 9;

            }
        }
        public static int threelength(int[] array)
        {
            string last = array[0].ToString();
            int myInt = int.Parse(last[last.Length - 1].ToString());

            string first = array[1].ToString();
            int second = int.Parse(first[first.Length - 1].ToString());

            if ((myInt == 0 || myInt == 5 || myInt == 6 || myInt == 1))
                return myInt;
            else
            {
                if (second == 0 || second == 4 || second == 6 || second == 2 || second == 8)
                    return mod(myInt, 0);
                else if (second == 5 || second == 9)
                {
                    if ((array[1] % 4 ==3) && (array[2] % 2 == 1))
                        return mod(myInt, 3);
                    else
                    return mod(myInt, 1);
                }
                else
                {
                    if (array[1] % 4 == 1)
                    {
                        return mod(myInt, 1);
                    }
                    else
                    {
                        if (array[2] % 2 == 0)
                            return mod(myInt, 1);
                        else
                            return mod(myInt, 3);
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Calculator.LastDigit(new int[0])); // 1),
            Console.WriteLine(Calculator.LastDigit(new int[] { 0, 0 }));                    // 1),
            Console.WriteLine(Calculator.LastDigit(new int[] { 0, 0, 0 }));             // 0),problem
            Console.WriteLine(Calculator.LastDigit(new int[] { 12342, 1456, 2050, 0, 123, 598 }));
            Console.WriteLine(Calculator.LastDigit(new int[] { 1, 2 }));                    //1),                                                                                            //Console.WriteLine(Calculator.LastDigit(new int[] { 3, 4, 5 }));             // 1) problem,
            Console.WriteLine(Calculator.LastDigit(new int[] { 4, 3, 6 }));             // 4),
            Console.WriteLine(Calculator.LastDigit(new int[] { 7, 6, 21 }));            // 1),
            Console.WriteLine(Calculator.LastDigit(new int[] { 12, 30, 21 }));          // 6),
            Console.WriteLine(Calculator.LastDigit(new int[] { 2, 2, 2, 0 }));              // 4),
            Console.WriteLine(Calculator.LastDigit(new int[] { 937640, 767456, 981242 }));  // 0),
            Console.WriteLine(Calculator.LastDigit(new int[] { 123232, 694022, 140249 }));  // 6),
            Console.WriteLine(Calculator.LastDigit(new int[] { 499942, 898102, 846073 }));  // 6),
            Console.WriteLine(Calculator.LastDigit(new int[] { 3, 4, 2 })); // 1
            Console.WriteLine(Calculator.LastDigit(new int[] { 1, 1, 0, 2, 1, 1, 2, 2, 0, 2, 0, 0, 0, 0, 1, 0 }));// 1
            Console.WriteLine(Calculator.LastDigit(new int[] { 416927, 95981, 594327, 692236, 391304, 349572, 695270 })); // 7
            Console.WriteLine(Calculator.LastDigit(new int[] { 82242, 254719, 736371 })); // 8
        }
    }
}
