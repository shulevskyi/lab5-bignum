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
    
    // Karatsuba multiplication

    public static BigInteger Karatsuba(BigInteger x, BigInteger y)
    {
        
        
        var nx = x.Digits.Count;
        var ny = y.Digits.Count;
        
        if (nx > ny)
        {
            Console.WriteLine("nx is bigger than ny");
            
            // Insert 0s at the beginning of y until the length of y is equal to the length of x
            for (int i = 0; i < nx - ny; i++)
            {
                y.Digits.Insert(0, 0);
            }
        }
        
        foreach (var digit in y.Digits)
        {
            Console.WriteLine(digit);
        }

        // Divide x into two halves a and b, and y into two halves c and d

        var a = x.Digits.GetRange(0, nx/2);
        var b = x.Digits.GetRange(nx/2, nx/2);
        var c = y.Digits.GetRange(0, ny/2);
        var d = y.Digits.GetRange(ny/2, ny/2);
        
        Console.WriteLine("a: " + string.Join("", a));
        Console.WriteLine("b: " + string.Join("", b));
        Console.WriteLine("c: " + string.Join("", c));
        Console.WriteLine("d: " + string.Join("", d));

        // ac recursively calls Karatsuba to compute ac
        
        var ac = Karatsuba(new BigInteger(string.Join("", a)), new BigInteger(string.Join("", c)));

        var bd = Karatsuba(new BigInteger(string.Join("", b)), new BigInteger(string.Join("", d)));
        
        // ad_plus_bc recursively calls Karatsuba(a+b, c+d) - ac - bd
        
        
        
        
        
        Console.WriteLine(ac);

        return null;
    }
    

}