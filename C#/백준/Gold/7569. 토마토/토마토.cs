using System;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]); // x
        int m = int.Parse(inputs[1]); // y
        int h = int.Parse(inputs[2]); // z

        int[ , , ] arr = new int[n, m, h];
        Queue<(int x, int y, int z, int day)> queue = new Queue<(int, int, int, int)>();

        for (int z = 0; z < h; z++)
        {
            for(int y = 0; y < m; y++)
            {
                string[] line = Console.ReadLine().Split();
                for (int x = 0; x < n; x++)
                {
                    int tomato = int.Parse(line[x]);
                    arr[x, y, z] = tomato;
                    if (tomato == 1)
                        queue.Enqueue((x, y, z, 0));
                }
            }
        }

        int[] dx = { -1, 1, 0, 0, 0, 0 };
        int[] dy = { 0, 0, -1, 1, 0, 0 };
        int[] dz = { 0, 0, 0, 0, -1, 1 };
        int maxDay = 0;
        //DFS 
        while (queue.Count > 0)
        {
            var (x, y, z, day) = queue.Dequeue();
            maxDay = Math.Max(maxDay, day);

            for(int i = 0 ; i < 6; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                int nz = z + dz[i];

                if(nx < 0 || nx >= n || ny < 0 || ny >= m || nz < 0 || nz >= h)
                {
                    continue;
                }

                if (arr[nx,ny,nz] == 0)
                {
                    arr[nx, ny, nz] = 1;
                    queue.Enqueue((nx, ny, nz, day + 1));
                }
            }
        }

        for(int x = 0; x < n; x++)
        {
            for(int y = 0; y < m; y++)
            {
                for( int z = 0; z < h; z++)
                {
                    if(arr[x,y,z] == 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                }
            }
        }

        Console.WriteLine(maxDay);
    }
}
