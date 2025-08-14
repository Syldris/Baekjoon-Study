#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] result = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < m; j++)
            {
                if (line[j] == arr[j])
                {
                    result[i]++;
                }
            }
        }

        int max = 0;
        int team = 1;
        for (int i = 1; i <= n; i++)
        {
            if (result[i] > max)
            {
                team = i;
                max = result[i];
            }
        }
        sw.Write(team);
    }
}
