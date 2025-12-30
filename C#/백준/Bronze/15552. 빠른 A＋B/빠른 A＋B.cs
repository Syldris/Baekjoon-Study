#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 65535);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 65535);

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(),int.Parse);
            sw.WriteLine(line[0] + line[1]);
        }
    }
}