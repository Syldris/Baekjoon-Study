using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];

        (int x, int y) babySharkPos = (0, 0);
        for (int y = 0; y < n; y++)
        {
            string[] line = Console.ReadLine().Split();
            for (int x = 0; x < n; x++)
            {
                int num = int.Parse(line[x]);
                arr[x, y] = num;
                if(num == 9)
                {
                    babySharkPos = (x, y);
                    arr[x, y] = 0;
                }
            }
        }

        int[] dx = { 0, -1, 0, 1 };
        int[] dy = { -1, 0, 1, 0 };

        int babySharkPower = 2;
        int pishEatCount = 0;
        int time = 0;

        BabyShark();

        void BabyShark()
        {
            while(true)
            {
                (int x, int y, int dist)? fish = BFS();
                if(fish == null)
                    break;

                (int x, int y, int dist) = fish.Value;
                time += dist;

                pishEatCount++;
                if (babySharkPower == pishEatCount)
                {
                    babySharkPower++;
                    pishEatCount = 0;
                }
                arr[x, y] = 0;
                babySharkPos = (x, y);
            }
            Console.WriteLine(time);
        }

        (int x, int y, int dist)? BFS()
        {
            PriorityQueue<(int x, int y, int curtime), int> queue = new();
            List <(int x, int y, int time)> fishlist = new List<(int, int, int)>();
            bool[,] visited = new bool[n, n];

            queue.Enqueue((babySharkPos.x, babySharkPos.y, 0), 0);
            while (queue.Count > 0)
            {
                (int x, int y, int curtime) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];

                    if (px < 0 || py < 0 || px >= n || py >= n)
                        continue;
                    if (visited[px, py] || arr[px, py] > babySharkPower)
                        continue;

                    visited[px, py] = true;
                    queue.Enqueue((px, py, curtime + 1), curtime + 1);

                    if (arr[px, py] != 0 && babySharkPower > arr[px, py])
                    {
                        fishlist.Add((px, py, curtime + 1));
                    }
                }
            }

            if (fishlist.Count == 0)
                return null;

            fishlist = fishlist.OrderBy(list => list.time).ThenBy(list => list.y).ThenBy(list => list.x).ToList();
            return fishlist[0];
        }
    }
}