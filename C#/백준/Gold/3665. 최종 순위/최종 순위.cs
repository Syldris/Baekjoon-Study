using System.Collections;
using System.Text;

public class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastCase = int.Parse(sr.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int t = 0; t < tastCase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int[] ranks = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int m = int.Parse(sr.ReadLine());

            List<int>[] graph = new List<int>[n + 1];
            int[] indegree = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    graph[ranks[i]].Add(ranks[j]);
                    indegree[ranks[j]]++;
                }
            }

            for (int i = 0; i < m; i++)
            {
                string[] line = sr.ReadLine().Split();
                int a = int.Parse(line[0]);
                int b = int.Parse(line[1]);
                if (graph[a].Contains(b))
                {
                    graph[a].Remove(b);
                    indegree[b]--;
                    graph[b].Add(a);
                    indegree[a]++;
                }
                else
                {
                    graph[b].Remove(a);
                    indegree[a]--;
                    graph[a].Add(b);
                    indegree[b]++;
                }
            }

            Queue<int> queue = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }

            int index = 0;
            int[] newRanks = new int[n];

            bool isWrong = false;

            while (queue.Count > 0)
            {
                if(queue.Count > 1)
                {
                    isWrong = true;
                    break;
                }

                int cur = queue.Dequeue();
                newRanks[index] = cur;
                index++;
                foreach (int next in graph[cur])
                {
                    indegree[next]--;
                    if(indegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            if (isWrong)
                sb.AppendLine("?");
            else if (index != n)
                sb.AppendLine("IMPOSSIBLE");
            else
                sb.AppendLine(String.Join(' ', newRanks));
        }
        sw.Write(sb);
    }
}
