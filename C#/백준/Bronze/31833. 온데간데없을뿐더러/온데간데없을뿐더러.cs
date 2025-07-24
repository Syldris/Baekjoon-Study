#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());
        string[] input = sr.ReadLine().Split();
        string[] input2 = sr.ReadLine().Split();

        string joina = string.Join("", input);
        string joinb = string.Join("", input2);

        BigInteger a = BigInteger.Parse(joina);
        BigInteger b = BigInteger.Parse(joinb);
        sw.Write(a >= b ? b : a);
    }
}
