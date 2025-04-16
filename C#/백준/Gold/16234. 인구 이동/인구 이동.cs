using System;
using System.Collections;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{

    static int n, l, r;

    static void Main()
    {
        string[] line = Console.ReadLine().Split();

        n = int.Parse(line[0]);
        l = int.Parse(line[1]);
        r = int.Parse(line[2]);

        int[,] arr = new int[n, n];
        for (int y = 0; y < n; y++)
        {
            string[] input = Console.ReadLine().Split(); ;
            for (int x = 0; x < n; x++)
            {
                arr[x,y] = int.Parse(input[x]);
            }
        }

        int count = 0;

        while (true)
        {
            List<List<(int x, int y)>> list = new List<List<(int, int)>>();
            bool[,] visited = new bool[n, n];
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    var result = (BFS(x, y, arr, visited));
                    if(result.Count > 1)
                    {
                        list.Add(result);
                    }
                }
            }

            if(list.Count == 0)
            {
                break;
            }

            count++;
            foreach (var item in list)
            {
                int value = 0;
                foreach (var pos in item)
                {
                    value += arr[pos.x, pos.y];
                }
                value = value / item.Count;

                foreach (var pos in item)
                {
                    arr[pos.x, pos.y] = value;
                }
            }
        }
        Console.WriteLine(count);

    }
    static List<(int, int)> BFS(int posx, int posy, int[,] arr, bool[,] visited)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int x,int y)> queue = new Queue<(int x, int y)>();
        queue.Enqueue((posx, posy));
        visited[posx,posy] = true;

        List<(int,int)> list = new List<(int,int)>();
        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            list.Add((x, y));
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= n || py >= n)
                    continue;

                int value = Math.Abs(arr[px, py] - arr[x, y]);

                if (!visited[px,py] && value >= l && value <= r)
                {
                    queue.Enqueue((px, py));
                    visited[px,py] = true;
                }
            }
        }
        return list;
    }
}
