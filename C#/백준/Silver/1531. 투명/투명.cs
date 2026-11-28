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

        int[,] board = new int[100, 100];
        
        // n <= 50 이니 최대 50만이니까 나이브하게 돌듯.

        for (int i = 0; i < n; i++)
        {
            int[] split = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            // 1-index => 0-index
            int startR = split[0] - 1;
            int startC = split[1] - 1;
            int endR = split[2] - 1;
            int endC = split[3] - 1;

            for (int r = startR; r <= endR; r++)
            {
                for (int c = startC; c <= endC; c++)
                {
                    board[r, c]++;
                }
            }
        }

        int answer = 0;

        for (int r = 0; r < 100; r++)
        {
            for (int c = 0; c < 100; c++)
            {
                if (board[r, c] > m) // m개를 초과해야 가려짐.
                    answer++;
            }
        }

        sw.Write(answer);
    }
}