#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[][] arr = new int[m][];

        for (int i = 0; i < m; i++)
        {
            arr[i] = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        }

        int first = arr[0][0];

        for (int i = 0; i < m - 1; i++)
        {
            arr[i][0] = arr[i + 1][0];
        }
        arr[^1][0] = first;

        sw.WriteLine(m);
        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(String.Join(' ', arr[i]));
        }
    }
}