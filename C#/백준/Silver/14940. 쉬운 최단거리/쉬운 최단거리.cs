using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        int[,] arr = new int[m, n]; //가로, 세로
        bool[,] visited = new bool[m, n];

        Queue<(int x, int y, int time)> queue = new Queue<(int, int, int)>();

        for (int y = 0; y < n; y++)
        {
            string[] line = Console.ReadLine().Split();
            for (int x = 0; x < m; x++)
            {
                int number = int.Parse(line[x]);
                arr[x, y] = number;
                if (number == 2)
                {
                    queue.Enqueue((x, y, 1));
                    arr[x, y] = 0;
                    visited[x, y] = true;
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();
            for(int i = 0; i < 4;  i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;
                if (!visited[px,py])
                {
                    if (arr[px,py] == 1)
                    {
                        visited[px,py] = true;
                        arr[px,py] = time;
                        queue.Enqueue((px, py, time + 1));
                    }
                    else if(arr[px,py] == 0)
                    {
                        visited[px,py] = true;
                    }
                }
            }
        }
        StringBuilder sb = new StringBuilder();
        for(int y = 0;  y < n; y++)
        {
            for(int x = 0; x < m; x++)
            {
                if (!visited[x, y] && arr[x,y] == 1)
                    arr[x, y] = -1;
                sb.Append($"{arr[x,y]} ");
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb);
    }
}
