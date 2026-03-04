#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        char[,] board = new char[m, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
            }
        }

        string text = sr.ReadLine();
        int len = text.Length;
        int[,,] visited = new int[m, n, len + 1];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k <= len; k++)
                    visited[i, j, k] = int.MaxValue;

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        (int x, int y)[,,] jumpTable = new (int, int)[m, n, 4]; // 값과 상관없이 움직일수 있는 위치가 고정이므로 그래프내에서 탐색보단 전처리로 구해놓자 
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                char c = board[x, y];
                for (int i = 0; i < 4; i++)
                {
                    jumpTable[x, y, i] = (-1, -1);

                    int px = x + dx[i];
                    int py = y + dy[i];

                    while (px >= 0 && py >= 0 && px < m && py < n)
                    {
                        if (board[px, py] != c) // 다른 키를 만나면 멈춤.
                        {
                            jumpTable[x, y, i] = (px, py);
                            break;
                        }

                        px += dx[i];
                        py += dy[i];
                    }
                }
            }
        }


        Queue<(int x, int y, int score, int count)> queue = new();
        visited[0, 0, 0] = 0;
        queue.Enqueue((0, 0, 0, 0));

        while (queue.Count > 0)
        {
            (int x, int y, int score, int count) = queue.Dequeue(); // x, y, 텍스트 입력 횟수, 입력한 횟수

            if (score == len && board[x, y] == '*')
            {
                sw.Write(count + 1);
                return;
            }

            if (score < len && board[x, y] == text[score] && count + 1 < visited[x, y, score + 1]) // 아직 입력이 남았고 현재 글자가 입력할 글자라면 입력
            {
                visited[x, y, score + 1] = count + 1;
                queue.Enqueue((x, y, score + 1, count + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                (int px, int py) = jumpTable[x, y, i];
                if (px == -1 || py == -1) continue;

                if (count + 1 < visited[px, py, score])
                {
                    visited[px, py, score] = count + 1;
                    queue.Enqueue((px, py, score, count + 1));
                }
            }
        }
    }
}