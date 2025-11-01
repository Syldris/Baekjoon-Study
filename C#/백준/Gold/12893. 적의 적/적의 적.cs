#nullable disable
using System;
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
        int[] color = new int[n + 1];

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            graph[a].Add(b);
            graph[b].Add(a);
        }

        bool result = true;
        Queue<int> queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            if (!result)
                break;
            if (color[i] != 0)
                continue;

            queue.Enqueue(i);
            color[i] = 1;

            while (queue.Count > 0 && result)
            {
                int pos = queue.Dequeue();
                foreach (int next in graph[pos])
                {
                    if (color[next] == 0)
                    {
                        color[next] = color[pos] * -1; 
                        queue.Enqueue(next);
                    }
                    else if (color[next] == color[pos])
                    {
                        result = false;
                        break;
                    }
                }
            }
        }

        sw.Write(result ? 1 : 0);
    }
}