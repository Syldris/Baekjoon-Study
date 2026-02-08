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

        int[,] boardA = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < m; j++)
            {
                boardA[i, j] = line[j];
            }
        }

        string[] input2 = sr.ReadLine().Split();
        int y = int.Parse(input2[0]);
        int x = int.Parse(input2[1]);

        int[,] boardB = new int[y, x];
        for (int i = 0; i < y; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < x; j++)
            {
                boardB[i, j] = line[j];
            }
        }

        long[][] result = new long[n][];
        for (int i = 0; i < n; i++)
        {
            result[i] = new long[x];
            for (int j = 0; j < m; j++)
            {
                long num1 = boardA[i, j];
                for (int k = 0; k < x; k++)
                {
                    long num2 = boardB[j, k];
                    result[i][k] += num1 * num2;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine(string.Join(' ', result[i]));
        }
    }
}