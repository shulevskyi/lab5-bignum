namespace lab5_bignum;
using lab5_bignum;

public class BigInteger
{
    public BigInteger(string value)
    {
        var digits = StrToInt(value);
        
        foreach (var digit in digits)
        {
            Console.WriteLine(digit);
        }
    }
    
    public static int[] StrToInt(string text)
    {
        // Function Converter to an array of digits
        
        int[] digits = new int[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            digits[i] = text[i] - '0';
        }
        
        return digits;
    }
    
    public BigInteger Add(BigInteger another)
    {
        // return new BigInteger, result of current + another
        return null;
    }
    
    public BigInteger Sub(BigInteger another)
    {
        // return new BigInteger, result of current - another
        return null;
    }
    

}