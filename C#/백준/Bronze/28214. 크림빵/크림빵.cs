#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int p = int.Parse(input[2]);
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int result = 0;
        int cur = 0;
        int value = 0;

        foreach (var item in arr)
        {
            if (item == 0)
            {
                value++;
            }
            if (++cur == k)
            {
                if(value < p)
                    result++;
                value = 0;
                cur = 0;
            }
        }
        sw.Write(result);
    }
}
