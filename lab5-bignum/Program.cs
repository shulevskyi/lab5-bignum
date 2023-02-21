using lab5_bignum;

var x = new BigInteger("123456789012345678901234567890").Digits;

// Call the Add function
var result = BigInteger.Sub(new BigInteger("430534"), new BigInteger("344"));

foreach (var digit in result.Digits)
{
    Console.Write(digit);
}