#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        string a = input[0];
        string b = input[1];

        int xPos = 0;
        int yPos = 0;
        bool find = false;
        for (int i = 0; i < a.Length; i++)
        {
            if (find) break;

            char c = a[i];
            for (int j = 0; j < b.Length; j++)
            {
                if (b[j] == c)
                {
                    (xPos, yPos) = (i, j);
                    find = true;
                    break;
                }
            }
        }

        char[][] board = new char[b.Length][];

        for (int i = 0; i < b.Length; i++)
        {
            board[i] = new char[a.Length];
            Array.Fill(board[i], '.');
        }

        for (int i = 0; i < a.Length; i++)
            board[yPos][i] = a[i];

        for(int i = 0; i < b.Length;i++)
            board[i][xPos] = b[i];

        for (int i = 0; i < b.Length; i++)
        {
            sw.WriteLine(new string(board[i]));
        }

    }
}