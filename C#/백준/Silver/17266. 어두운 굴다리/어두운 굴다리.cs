#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int result = Math.Max(arr[0], n - arr[^1]);
        for (int i = 1; i < m; i++)
        {
            int value = (arr[i] - arr[i - 1]) / 2;
            if ((arr[i] - arr[i - 1]) % 2 != 0)
            {
                value++;
            }
            result = Math.Max(result, value);
        }

        sw.Write(result);
    }
}