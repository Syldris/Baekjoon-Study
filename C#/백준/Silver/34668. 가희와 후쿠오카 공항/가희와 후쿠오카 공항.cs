#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int q = int.Parse(sr.ReadLine());

        for (int i = 0; i < q; i++)
        {
            int n = int.Parse(sr.ReadLine());
            n++;

            int bus = n / 50;
            if (n % 50 != 0)
            {
                bus++;
            }

            int time = 360;
            int value = bus * 12 - 6;

            time += value;
            if (time >= 1440)
            {
                sw.WriteLine(-1);
            }
            else
            {
                sw.WriteLine($"{time / 60:D2}:{time % 60:D2}");
            }
        }
    }
}