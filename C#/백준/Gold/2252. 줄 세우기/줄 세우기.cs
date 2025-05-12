using System;
using System.Text;
public class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        int[] indegree = new int[n + 1];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int front = int.Parse(line[0]);
            int back = int.Parse(line[1]);
            graph[front].Add(back);
            indegree[back]++;
        }

        Queue<int> queue = new Queue<int>();

        for (int i = 1; i <= n; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        StringBuilder sb = new StringBuilder();

        while (queue.Count > 0)
        {
            int cur = queue.Dequeue();
            sb.Append(cur).Append(' ');

            foreach (int next in graph[cur])
            {
                indegree[next]--;
                if(indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        sw.Write(sb);

    }
}
