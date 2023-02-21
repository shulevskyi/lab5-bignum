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
        Console.WriteLine(string.Join("", result));
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
            
            int sum = aDigit - bDigit;
            
            if (sum < 0)
            {
                result.Add(sum + 10);
                result.Add(-1);
            }
            else
            {
                result.Add(sum);
            }
            
            aLastIndex--;
            bLastIndex--;
        }
        
        result.Reverse();
        Console.WriteLine(string.Join("", result));
        return new BigInteger(string.Join("", result));
    }

}