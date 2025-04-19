using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int m = int.Parse(inputs[0]);
        int n = int.Parse(inputs[1]);

        int[,] arr = new int[m, n];
        Queue<(int x, int y, int day)> queue = new Queue<(int, int, int)>();

        for (int y = 0; y < n; y++)
        {
            string[] text = Console.ReadLine().Split();
            for (int x = 0; x < m ; x++)
            {
                arr[x,y] = int.Parse(text[x]);
                if (arr[x, y] == 1)
                    queue.Enqueue((x, y, 0));
            }
        }

        int[] dx = { -1, 1, 0, 0 }; //좌우
        int[] dy = { 0, 0, -1, 1 }; //상하
        int maxday = 0;

        while (queue.Count > 0)
        {
            var (x,y,day) = queue.Dequeue();
            maxday = Math.Max(maxday, day);

            for(int i = 0; i < 4; i++) //상하좌우 검사
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if(nx < 0 || ny < 0 || nx >= m || ny >= n)
                    continue;
                if (arr[nx,ny] == 0)
                {
                    arr[nx, ny] = 1;
                    queue.Enqueue((nx, ny, day + 1));
                }
            }
        }

        for (int x = 0; x < m; x++)
        {
            for(int y = 0; y < n; y++)
            {
                if(arr[x,y] == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
        Console.WriteLine(maxday);
    }
}
