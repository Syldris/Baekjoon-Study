using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int v = int.Parse(inputs[0]);
            int e = int.Parse(inputs[1]);
            List<int>[] graph = new List<int>[v+1];

            for(int n = 1; n<=v; n++)
            {
                graph[n] = new List<int>();
            }

            for(int j = 0; j < e; j++)
            {
                string[] line = Console.ReadLine().Split();
                int start = int.Parse(line[0]);
                int end = int.Parse(line[1]);
                graph[start].Add(end);
                graph[end].Add(start);
            }

            int[] color = new int[v + 1];
            Array.Fill(color, -1);

            bool isTwoColor = true;

            for (int start = 1; start < color.Length; start++)
            {
                if(!isTwoColor)
                    break;
                if (color[start] != -1)
                    continue;

                color[start] = 0;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                while (queue.Count > 0)
                {
                    if (!isTwoColor)
                        break;
                    int num = queue.Dequeue();
                    foreach (var next in graph[num])
                    {
                        if (color[next] == -1)
                        {
                            color[next] = 1 - color[num]; // 0=>1=>0=>1 반복
                            queue.Enqueue(next);
                        }
                        else if (color[next] == color[num])
                        {
                            isTwoColor = false;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(isTwoColor ? "YES" : "NO");
        }
    }
}