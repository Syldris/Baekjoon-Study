#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        while (true)
        {
            string input = sr.ReadLine();
            if (input == null)
                return;
            string[] inputs = input.Split();
            int n = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            int result = 0;
            int cur = 0;
            int coupon = n;
            while (coupon > 0)
            {
                result += coupon;
                cur += coupon;
                coupon = cur / k;
                cur = cur % k;
            }
            sw.WriteLine(result);
        }
    }
}
