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
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 1; j < line[0]; j++)
            {
                graph[line[j]].Add(line[j + 1]);
                indegree[line[j + 1]]++;
            }
        }

        int count = 0;
        Queue<int> queue = new Queue<int>();
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= n; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        while(queue.Count > 0)
        {
            int cur = queue.Dequeue();
            sb.Append(cur).Append('\n');
            count++;

            foreach (int next in graph[cur])
            {
                indegree[next]--;
                if (indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        sw.WriteLine(count == n ? sb : 0);
    }
}
