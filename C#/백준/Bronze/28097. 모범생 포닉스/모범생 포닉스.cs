#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = 0;
        foreach (var item in arr)
        {
            sum += item;
        }
        sum += (n - 1) * 8;
        sw.Write($"{sum / 24} {sum % 24}");
    }
}