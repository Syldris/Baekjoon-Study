#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = sr.ReadLine().Split().Skip(1).Select(int.Parse).ToArray();
            int value = 0;

            foreach (var item in line)
            {
                value += item;
            }
            arr[i] = value;
        }

        Array.Sort(arr);

        long[] sum = new long[n];
        sum[0] = arr[0];
        long result = arr[0];

        for (int i = 1; i < n; i++)
        {
            sum[i] += sum[i - 1] + arr[i];
            result += sum[i];
        }
        sw.Write(result);
    }
}