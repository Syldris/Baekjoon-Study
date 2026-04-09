#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int min = int.MaxValue;
        int diff = 0;

        for (int i = 0; i < n; i++)
        {
            min = Math.Min(min, arr[i]);
            diff = Math.Max(diff, arr[i] - min); // 시세차익 최대.
        }

        sw.Write(diff);
    }
}