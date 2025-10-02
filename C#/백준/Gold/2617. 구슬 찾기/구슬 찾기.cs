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

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        bool[,] heavylink = new bool[n + 1, n + 1];
        bool[,] lightlink = new bool[n + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            heavylink[a, b] = true;
            lightlink[b, a] = true;
        }


        int[] heavyvalue = new int[n + 1];
        int[] lightvalue = new int[n + 1];

        int point = n / 2 + n % 2;
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            bool[] visited = new bool[n + 1];

            heavyvalue[i] += heavyDFS(i, visited);
            Array.Fill(visited, false);
            lightvalue[i] += lightDFS(i, visited);
            if (heavyvalue[i] >= point || lightvalue[i] >= point)
            {
                result++;
            }
        }

        sw.Write(result);

        int heavyDFS(int start, bool[] visited)
        {
            int value = 0;
            for (int i = 1; i <= n; i++)
            {
                if(i == start)
                    continue;

                if (heavylink[start, i] && !visited[i])
                {
                    visited[i] = true;
                    value++;
                    value += heavyDFS(i,visited);
                }
            }
            return value;
        }

        int lightDFS(int start, bool[] visited)
        {
            int value = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i == start)
                    continue;

                if (lightlink[start, i] && !visited[i])
                {
                    visited[i] = true;
                    value++;
                    value += lightDFS(i, visited);
                }
            }
            return value;
        }
    }
}
