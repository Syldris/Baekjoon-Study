#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        bool filp = false;

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n - 1; x++)
            {
                if(!filp) sw.Write("* ");
                else sw.Write(" *");
            }

            if (!filp) sw.Write("*");
            else sw.Write(" *");

            if (y != n - 1)
            {
                sw.WriteLine();
                filp = !filp;
            }
        }
    }
}