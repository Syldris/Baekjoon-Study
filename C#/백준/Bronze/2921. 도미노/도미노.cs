#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int result = 0;

        for (int i = 0; i <= n; i++)
        {
            for (int j = i; j <= n; j++)
            {
                result += i + j;
            }
        }
        sw.Write(result);
    }
}