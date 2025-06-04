#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        int value = 0;
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
            value += arr[i];
        }
        int avg = value / n;
        int output = 0;
        for (int i = 0; i < n; i++)
        {
            output += Math.Abs(arr[i] - avg);
        }
        sw.Write(output / 2);
    }
}