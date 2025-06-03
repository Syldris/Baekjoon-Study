#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long[] inputs = sr.ReadLine().Split().Select(long.Parse).ToArray();
        long white = inputs[0];
        long black = inputs[1];
        sw.Write(white >= black ? black : white + 1);
    }
}