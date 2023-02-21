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
            int carry = 0;

            int i = a.Digits.Count - 1;
            int j = b.Digits.Count - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += a.Digits[i];
                    i--;
                }

                if (j >= 0)
                {
                    sum += b.Digits[j];
                    j--;
                }

                int digit = sum % 10;
                carry = sum / 10;

                result.Insert(0, digit);
            }

            return new BigInteger(string.Join("", result));
        }


        public static BigInteger Sub(BigInteger a, BigInteger b)
        {
            var result = new List<int>();

            // Get the last index of a and b
            int aLastIndex = a.Digits.Count - 1;
            int bLastIndex = b.Digits.Count - 1;

            // While there are still digits to subtract
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
                    int borrow = 1;
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
                    else
                    {
                        borrow = -1;
                    }

                    diff = (aDigit + 10 * borrow) - bDigit;
                }

                result.Add(diff);

                aLastIndex--;
                bLastIndex--;
            }

            // Remove any leading zeros from the result
            while (result.Count > 1 && result[result.Count - 1] == 0)
            {
                result.RemoveAt(result.Count - 1);
            }

            result.Reverse();
            //Console.WriteLine(string.Join("", result));
            return new BigInteger(string.Join("", result));
        }


        // Karatsuba multiplication
        

    }
}


