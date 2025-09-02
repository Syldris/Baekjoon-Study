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
        string[] texts = new string[n];
        for (int i = 0; i < n; i++)
        {
            texts[i] = sr.ReadLine();
        }
        int[] cost = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int general = int.Parse(sr.ReadLine());
        for (int i = 0; i < 6; i++)
        {
            cost[i] = Math.Min(cost[i], general);
        }
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            int cur = 0;
            char c = texts[i][0];
            foreach (var item in texts[i])
            {
                if (item != c)
                {
                    cur = 0;
                    result += texts[i].Length * general;
                    break;
                }
                switch (item)
                {
                    case 'P':
                        cur += cost[0]; break;
                    case 'C':
                        cur += cost[1]; break;
                    case 'V':
                        cur += cost[2]; break;
                    case 'S':
                        cur += cost[3]; break;
                    case 'G':
                        cur += cost[4]; break;
                    case 'F':
                        cur += cost[5]; break;
                    case 'O':
                        cur += general; break;
                }
            }
            result += cur;
        }
        sw.Write(result);
    }
}
