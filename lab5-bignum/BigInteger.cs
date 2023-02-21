namespace lab5_bignum;
using lab5_bignum;

public class BigInteger
{
    
    public List<int> Digits { get; }
    public BigInteger(string value)
    {
        // Convert value to a list of digits through a Func 
        Digits = StringToDigits(value);
    }
    
    // Function to convert a string to a list of digits
    private static List<int> StringToDigits(string value)
    {
        var digits = new List<int>();
        foreach (var c in value)
        {
            digits.Add(c - '0');
        }
        return digits;
    }
    
}