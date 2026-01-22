#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] sorted = arr.ToArray();
        Array.Sort(sorted);

        int max = arr[0];
        for (int i = 0; i < n; i++)
        {
            if (max - arr[i] > k)
            {
                sw.Write("NO");
                return;
            }
            max = Math.Max(arr[i], max);
        }

        sw.Write("YES");
    }
}