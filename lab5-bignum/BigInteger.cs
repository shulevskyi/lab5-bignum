namespace lab5_bignum;
using lab5_bignum;

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
        var carry = 0;

        // both vars are the indexes of the last digit
        var i = a.Digits.Count - 1;
        var j = b.Digits.Count - 1;

        // while there are still digits to add
        while (i >= 0 || j >= 0)
        {
            var sum = carry;


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

            result.Add(sum % 10);
            carry = sum / 10;
        }

        if (carry > 0)
        {
            result.Add(carry);
        }

        // reverse the list to get the correct order
        result.Reverse();
        Console.WriteLine(string.Join("", result));
        return new BigInteger(string.Join("", result));
    }
    
    

}