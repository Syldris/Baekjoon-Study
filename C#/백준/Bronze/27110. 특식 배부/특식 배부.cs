#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int a = input[0];
        int b = input[1];
        int c = input[2];
        int value = Math.Min(a, n) + Math.Min(b, n) + Math.Min(c, n);
        sw.Write(value);
    }
}