#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] pos = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] time = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int result = Math.Max(pos[^1], time[^1]);
        for (int i = n - 2; i >= 0; i--)
        {
            result += pos[i + 1] - pos[i];
            result = Math.Max(time[i], result);
        }
        result += pos[0];

        sw.Write(result);
    }
}