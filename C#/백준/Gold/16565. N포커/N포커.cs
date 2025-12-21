#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        if (n < 4)
        {
            sw.Write(0);
            return;
        }
        int rank = n / 4;
        long result = 0;
        for (int i = 1; i <= rank; i++)
        {
            int card = n - i * 4;
            long value = Ncr(52 - i * 4, card);
            for (int j = 1; j <= card / 4; j++)
            {
                if (j % 2 == 1)
                {
                    value -= Ncr(13 - i , j) * Ncr(52 - j * 4 - i*4, card - j * 4);
                }
                else
                {
                    value += Ncr(13 - i, j) * Ncr(52 - j * 4 - i * 4, card - j * 4);
                }
            }

            result = (result + Ncr(13, i) * value) % 10007;
        }
        sw.WriteLine(result);

        long Ncr(int n, int r)
        {
            long value = 1;
            for (int i = 1; i <= r; i++)
            {
                value = value * (n - r + i) / i;
            }
            return value;
        }
    }
}