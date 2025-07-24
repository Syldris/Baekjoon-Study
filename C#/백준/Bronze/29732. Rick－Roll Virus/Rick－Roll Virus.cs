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
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);
        bool[] arr = new bool[n];
        string line = sr.ReadLine();
        for (int i = 0; i < n; i++)
        {
            if (line[i] == 'R')
            {
                arr[i] = true;
                for (int j = 1; j <= k; j++)
                {
                    if (i - j >= 0)
                    {
                        arr[i - j] = true;
                    }
                    if (i + j < n)
                    {
                        arr[i + j] = true;
                    }
                }
            }
        }
        int result = 0;
        foreach (var item in arr)
        {
            if(item)
                result++;
        }
        sw.Write(m >= result ? "Yes" : "No");

    }
}
