#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        bool[,] board = new bool[n, n];
        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                board[x, y] = line[x] == '*' ? true : false;
            }
        }

        (int x, int y) point = (0, 0);

        for (int y = 1; y < n - 1; y++)
        {
            for (int x = 1; x < n - 1; x++)
            {
                if (Check(x, y))
                {
                    point = (x, y);
                    break;
                }
            }
        }

        int leftHand = lenCheck(point.x, point.y, 1);
        int rightHand = lenCheck(point.x, point.y, 2);

        int body = lenCheck(point.x, point.y, 0);

        int leftleg = lenCheck(point.x - 1, point.y + body + 1, 0) + 1;
        int rightleg = lenCheck(point.x + 1, point.y + body + 1, 0) + 1;


        sw.WriteLine($"{point.y + 1} {point.x + 1}");
        sw.WriteLine($"{leftHand} {rightHand} {body} {leftleg} {rightleg}");

        bool Check(int x, int y)
        {
            if (board[x, y] && board[x - 1, y] && board[x + 1, y] && board[x, y - 1] && board[x, y + 1])
            {
                return true;
            }
            return false;
        }

        int lenCheck(int x, int y, int mod)
        {
            int[] dx = new int[] { 0, -1, 1 };
            int[] dy = new int[] { 1, 0, 0 };

            int px = x + dx[mod];
            int py = y + dy[mod];
            if (px < 0 || py < 0 || px >= n || py >= n) return 0;
            else if (!board[px, py]) return 0;

            return lenCheck(px, py, mod) + 1;
        }
    }
}