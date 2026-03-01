#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        while (true)
        {
            int x = int.Parse(sr.ReadLine());
            if(x == 0) break;

            if (x % n == 0) sw.WriteLine($"{x} is a multiple of {n}.");
            else sw.WriteLine($"{x} is NOT a multiple of {n}.");
        }
    }
}