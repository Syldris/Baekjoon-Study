#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int odd = 0;
        int even = 0;
        foreach (var item in arr)
        {
            if (item % 2 == 0)
            {
                even++;
            }
            else
            {
                odd++;
            }
        }

        if (n % 2 == 0 && odd == even)
        {
            sw.Write(1);
        }
        else if(n % 2 == 1 && odd-1 == even)
        {
            sw.Write(1);
        }
        else
        {
            sw.Write(0);
        }
    }
}
