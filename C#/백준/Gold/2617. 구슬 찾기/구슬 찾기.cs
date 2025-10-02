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

        bool[,] link = new bool[n + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            link[a, b] = true;
        }



        int point = n / 2 + n % 2;
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            bool[] visited = new bool[n + 1];

            int heavy = DFS(i, visited);
            Array.Fill(visited, false);
            int light = DFS(i, visited, false);
            if (heavy >= point || light >= point)
            {
                result++;
            }
        }

        sw.Write(result);

        int DFS(int start, bool[] visited, bool heavy = true)
        {
            int value = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i == start)
                    continue;

                if (heavy)
                {
                    if (link[start, i] && !visited[i])
                    {
                        visited[i] = true;
                        value++;
                        value += DFS(i, visited);
                    }
                }
                else
                {
                    if (link[i, start] && !visited[i])
                    {
                        visited[i] = true;
                        value++;
                        value += DFS(i, visited, false);
                    }
                }
            }
            return value;
        }
    }
}
