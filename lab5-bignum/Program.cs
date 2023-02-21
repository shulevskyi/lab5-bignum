// See https://aka.ms/new-console-template for more information

using lab5_bignum;

var x = new BigInteger("123456789012345678901234567890").Digits;

foreach (var d in x)
{
    Console.WriteLine(d);
}

