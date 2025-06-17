#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int L = int.Parse(sr.ReadLine());
        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        int c = int.Parse(sr.ReadLine());
        int d = int.Parse(sr.ReadLine());

        int day = 0;
        while (a > 0 || b > 0)
        {
            a -= c;
            b -= d;
            day++;
        }
        sw.Write(L - day);

    }
}