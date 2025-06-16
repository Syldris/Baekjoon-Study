#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcase; t++)
        {
            int[] arr = sr.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            sw.WriteLine($"{sum} {arr.Min()}");
        }
    }
}