#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        for (int i = 1; i < n; i++)
        {
            sw.Write(new string('*', i));
            sw.Write(new string(' ', n * 2 - i * 2));
            sw.Write(new string('*', i));
            sw.WriteLine();
        }
        sw.WriteLine(new string('*', n * 2));

        for (int i = n - 1; i > 0; i--)
        {
            sw.Write(new string('*', i));
            sw.Write(new string(' ', n * 2 - i * 2));
            sw.Write(new string('*', i));
            sw.WriteLine();
        }
    }
}