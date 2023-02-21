namespace lab5_bignum
{
    using System;
    using System.Collections.Generic;

    public class BigInteger
    {

        public List<int> Digits { get; }

        public BigInteger(string value)
        {
            Digits = StringToDigits(value);
        }


        private static List<int> StringToDigits(string value)
        {
            var digits = new List<int>();
            foreach (var c in value)
            {
                digits.Add(c - '0');
            }

            return digits;
        }


        public static BigInteger Add(BigInteger a, BigInteger b)
        {
            var result = new List<int>();

            // Get the last index of a and b
            int aLastIndex = a.Digits.Count - 1;
            int bLastIndex = b.Digits.Count - 1;

            // While there are still digits to add
            while (aLastIndex >= 0 || bLastIndex >= 0)
            {
                int aDigit = 0;
                int bDigit = 0;

                if (aLastIndex >= 0)
                {
                    aDigit = a.Digits[aLastIndex];
                }

                if (bLastIndex >= 0)
                {
                    bDigit = b.Digits[bLastIndex];
                }

                int sum = aDigit + bDigit;

                if (sum > 9)
                {
                    result.Add(sum - 10);
                    result.Add(1);
                }
                else
                {
                    result.Add(sum);
                }

                aLastIndex--;
                bLastIndex--;
            }

            result.Reverse();
            //Console.WriteLine(string.Join("", result));
            return new BigInteger(string.Join("", result));
        }

        public static BigInteger Sub(BigInteger a, BigInteger b)
        {
            var result = new List<int>();

            // Get the last index of a and b
            int aLastIndex = a.Digits.Count - 1;
            int bLastIndex = b.Digits.Count - 1;

            // While there are still digits to add
            while (aLastIndex >= 0 || bLastIndex >= 0)
            {
                int aDigit = 0;
                int bDigit = 0;

                if (aLastIndex >= 0)
                {
                    aDigit = a.Digits[aLastIndex];
                }

                if (bLastIndex >= 0)
                {
                    bDigit = b.Digits[bLastIndex];
                }

                int diff = aDigit - bDigit;

                if (diff < 0)
                {
                    result.Add(diff + 10);
                    int nextIndex = aLastIndex - 1;
                    while (nextIndex >= 0 && a.Digits[nextIndex] == 0)
                    {
                        a.Digits[nextIndex] = 9;
                        nextIndex--;
                    }

                    if (nextIndex >= 0)
                    {
                        a.Digits[nextIndex]--;
                    }
                }
                else
                {
                    result.Add(diff);
                }

                aLastIndex--;
                bLastIndex--;
            }

            result.Reverse();
            //Console.WriteLine(string.Join("", result));
            return new BigInteger(string.Join("", result));
        }

        // Karatsuba multiplication
    }
}


