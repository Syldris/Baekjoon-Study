#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            char[,] board = new char[m + 2, n + 2];
            (int x, int y) con1 = (-1, -1);
            (int x, int y) con2 = (-1, -1);

            int[,,] distance = new int[m + 2, n + 2, 3];

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int y = 0; y < n + 2; y++)
            {
                for (int x = 0; x < m + 2; x++)
                {
                    distance[x, y, 0] = int.MaxValue;
                    distance[x, y, 1] = int.MaxValue;
                    distance[x, y, 2] = int.MaxValue;
                    board[x, y] = '.';
                }
            }

            for (int y = 1; y <= n; y++)
            {
                string line = sr.ReadLine();
                for (int x = 1; x <= m; x++)
                {
                    board[x, y] = line[x-1];

                    if (line[x-1] == '$')
                    {
                        board[x, y] = '.';
                        if(con1 == (-1,-1))
                            con1 = (x,y);
                        else
                            con2 = (x,y);
                    }
                }
            }


            PriorityQueue<(int x, int y, int cost, int value), int> queue = new();

            queue.Enqueue((0, 0, 0, 0), 0);

            distance[con1.x, con1.y, 1] = 0;
            distance[con2.x, con2.y, 2] = 0;
            queue.Enqueue((con1.x, con1.y, 0, 1), 0);
            queue.Enqueue((con2.x, con2.y, 0, 2), 0);    

            while (queue.Count > 0)
            {
                (int x, int y, int cost, int value) = queue.Dequeue();

                if (cost > distance[x, y, value])
                    continue;

                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if(px < 0 || py < 0 || px >= m + 2 || py >= n + 2)
                        continue;
                    if (board[px, py] == '*')
                        continue;

                    if (board[px, py] == '.')
                    {
                        if (cost < distance[px, py, value])
                        {
                            distance[px,py,value] = cost;
                            queue.Enqueue((px, py, cost, value), cost);
                        }
                    }

                    if (board[px, py] == '#')
                    {
                        int curcost = cost + 1;
                        if (curcost < distance[px, py, value])
                        {
                            distance[px,py,value] = curcost;
                            queue.Enqueue((px, py, curcost, value), curcost);
                        }
                    }
                }
            }

            int minValue = int.MaxValue;
            for (int y = 0; y < n + 2; y++)
            {
                for (int x = 0; x < m + 2; x++)
                {
                    int value1 = distance[x, y, 0];
                    int value2 = distance[x, y, 1];
                    int value3 = distance[x, y, 2];

                    if (board[x,y] == '*')
                        continue;
                    if (value1 == int.MaxValue || value2 == int.MaxValue || value3 == int.MaxValue)
                        continue;

                    int value = value1 + value2 + value3;
                    if (board[x, y] == '#')
                        value -= 2;

                    minValue = Math.Min(minValue, value);
                }
            }
            sw.WriteLine(minValue);
        }
    }
}