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

            int front = line[0];
            int back = line[1];
            graph[front].Add(back);
            indegree[back]++;
        }

        PriorityQueue<int, int> queue = new();
        for (int i = 1; i <= n; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i, i);
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
                    queue.Enqueue(next, next);
            }
        }
        sw.Write(sb);
    }
}
