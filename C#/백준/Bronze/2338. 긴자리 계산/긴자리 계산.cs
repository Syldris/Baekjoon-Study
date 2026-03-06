#nullable disable
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        BigInteger a = BigInteger.Parse(sr.ReadLine());
        BigInteger b = BigInteger.Parse(sr.ReadLine());
        sw.WriteLine(a + b);
        sw.WriteLine(a - b);
        sw.WriteLine(a * b);
    }
}