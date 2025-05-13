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
            string[] input1 = sr.ReadLine().Split();
            int n = int.Parse(input1[0]);
            int k = int.Parse(input1[1]);

            int[] delayTime = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int[] indegree = new int[n + 1];
            int[] dp = new int[n + 1];
            for(int i =  0; i < n; i++)
            {
                dp[i + 1] = delayTime[i];
            }
            List<int>[] graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
            }
            
            for (int i = 0; i < k; i++)
            {
                string[] line = sr.ReadLine().Split();
                int front = int.Parse(line[0]);
                int back = int.Parse(line[1]);

                graph[front].Add(back);
                indegree[back]++;
            }

            int endPos = int.Parse(sr.ReadLine());

            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }


            while(queue.Count > 0)
            {
                int curPos = queue.Dequeue();
                if (curPos == endPos)
                {
                    sb.Append(dp[curPos]).Append('\n');
                }
                foreach(int next in graph[curPos])
                {
                    indegree[next]--;
                    dp[next] = Math.Max(dp[curPos] + delayTime[next - 1], dp[next]);
                    if (indegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

        }
        sw.Write(sb);
    }
}
