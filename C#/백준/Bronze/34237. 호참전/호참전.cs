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

        (int a, int b)[] arr = new (int x, int y)[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            arr[i] = (line[0], line[1]);
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int game = line[0];
            int x = line[1];
            int y = line[2];

            int result = 0;
            foreach ((int a, int b) in arr)
            {
                if (x <= a && y <= b && a + b <= game)
                {
                    result++;
                }
            }

            sw.WriteLine(result);
        }
    }
}