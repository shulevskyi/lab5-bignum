using System;

namespace lab5_bignum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = new BigInteger("550");
            BigInteger b = new BigInteger("550");

            BigInteger sum = BigInteger.Add(a, b);
            BigInteger diff = BigInteger.Sub(a, b);

            Console.WriteLine($"a + b = {string.Join("", sum.Digits)}");
            Console.WriteLine($"a - b = {string.Join("", diff.Digits)}");
        }
    }
}