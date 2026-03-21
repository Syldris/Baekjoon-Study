#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[,] memo = new int[6, 2];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int gender = line[0];
            int year = line[1] - 1;
            memo[year, gender]++;
        }

        int result = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result += (memo[i, j] + k - 1) / k;
            }
        }
        sw.Write(result);
    }
}