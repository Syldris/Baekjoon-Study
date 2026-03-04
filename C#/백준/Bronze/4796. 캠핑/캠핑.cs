#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int index = 0;
        while (true)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int l = arr[0];
            int p = arr[1];
            int v = arr[2];

            if (l == 0 && p == 0 && v == 0) break;

            int value = 0;

            int k = v / p;

            value += l * k;
            value += Math.Min(l, v - p * k);

            sw.WriteLine($"Case {++index}: {value}");
        }

    }
}