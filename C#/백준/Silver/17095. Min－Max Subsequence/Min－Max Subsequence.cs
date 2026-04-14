#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int min = arr.Min();
        int max = arr.Max();

        if (min == max)
        {
            sw.Write(1);
            return;
        }

        int result = int.MaxValue;
        int lastMinIndex = -1;
        int lastMaxIndex = -1;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == min)
                lastMinIndex = i;

            else if (arr[i] == max)
                lastMaxIndex = i;

            if (lastMinIndex != -1 && lastMaxIndex != -1)
            {
                result = Math.Min(result, Math.Abs(lastMinIndex - lastMaxIndex) + 1);
            }
        }

        sw.Write(result);

    }
}