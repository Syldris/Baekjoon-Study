#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int col = int.Parse(input[2]) + 1;
        int row = int.Parse(input[1]) + 1;

        Sovle(n, 1, 1, 0);

        void Sovle(int n, int x, int y, int value)
        {
            if (n == 0)
            {
                sw.WriteLine(value);
                return;
            }

            int size = Sqrt2(n - 1);
            if (col < x + size && row < y + size) //2사분면
            {
                Sovle(n - 1, x, y, value);
            }
            else if (col >= x + size && row < y + size) //1사분면
            {
                Sovle(n - 1, x + size, y, (size * size) + value);
            }
            else if (col < x + size && row >= y + size) //3사분면
            {
                Sovle(n - 1, x, y + size, (size * size) * 2 + value);
            }
            else//4사분면
            {
                Sovle(n - 1, x + size, y + size, (size * size) * 3 + value);
            }
        }

        int Sqrt2(int n)
        {
            int value = 1;
            for (int i = 0; i < n; i++)
            {
                value *= 2;
            }
            return value;
        }
    }
}