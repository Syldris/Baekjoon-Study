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
        int score = int.Parse(input[1]);
        int rank = int.Parse(input[2]);

        if (n == 0)
        {
            sw.Write(1);
            return;
        }

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        Array.Sort(arr);
        Array.Reverse(arr);

        int p = arr.Where(x => x == score).Count();
        for (int i = 0; i < arr.Length; i++)
        {
            if (score >= arr[i])
            {
                if (i + p + 1 > rank)
                {
                    sw.Write(-1);
                }
                else
                {
                    sw.Write(i + 1);
                }
                return;
            }
        }
        if (n+1 > rank)
        {
            sw.Write(-1);
        }
        else
        {
            sw.Write(n + 1);
        }
    }
}