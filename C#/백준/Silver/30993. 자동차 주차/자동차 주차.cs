#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        long n = factorial(arr[0]);
        long a = factorial(arr[1]);
        long b = factorial(arr[2]);
        long c = factorial(arr[3]);

        sw.Write(n / (a * b * c));
        long factorial(int value)
        {
            long result = 1;
            for (int i = value; i >= 2; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
