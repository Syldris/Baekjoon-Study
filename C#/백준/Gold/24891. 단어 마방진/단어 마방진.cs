#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        string[] text = new string[m];
        for (int i = 0; i < m; i++)
        {
            text[i] = sr.ReadLine();
        }

        Array.Sort(text);

        bool find = false;

        string[] board = new string[n];
        bool[] chioce = new bool[m];

        BackTrack(0);

        if (!find)
            sw.Write("NONE");

        void BackTrack(int depth)
        {
            if (find) return;

            if (depth == n)
            {
                find = true;
                for (int i = 0; i < n; i++)
                {
                    sw.WriteLine(board[i]);
                }
                return;
            }

            for (int i = 0; i < m; i++)
            {
                if (chioce[i]) continue;

                bool check = true;

                for (int j = 0; j < depth; j++)
                {
                    if (text[i][j] != board[j][depth]) // 가로 세로 가지치기 확인
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    chioce[i] = true;
                    board[depth] = text[i];

                    BackTrack(depth + 1);
                    chioce[i] = false;
                }
            }
        }
    }
}