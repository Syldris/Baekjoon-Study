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
        int value = 1;
        for (int i = 1; i < n; i++)
        {
            if ((arr[i] + arr[i - 1]) % 2 == 1)
            {
                value++;
            }
        }
        sw.Write(value);
    }
}
