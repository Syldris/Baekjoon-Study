#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        for (int i = 2; i <= n; i++)
        {
            while (n % i == 0)
            {
                sw.WriteLine(i);
                n /= i;
            }
        }
    }
}