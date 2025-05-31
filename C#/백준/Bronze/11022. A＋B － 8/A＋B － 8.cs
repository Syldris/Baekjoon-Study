#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            int[] values = sr.ReadLine().Split().Select(int.Parse).ToArray();
            sw.WriteLine($"Case #{i}: {values[0]} + {values[1]} = {values[0] + values[1]}");
        }
    }
}