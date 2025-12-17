#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int result = 0;
        string line = sr.ReadLine();
        bool[] game = new bool[12];
        for (int i = 0; i < 12; i++)
        {
            if (line[i] == 'Y')
            {
                game[i] = true;
            }
        }

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);

        for (int i = 1; i <= 6; i++)
        {
            if (game[i - 1])
            {
                int value = i * 2;
                if (a == i)
                    value += i;
                if (b == i)
                    value += i;
                if (c == i)
                    value += i;
                result = Math.Max(result, value);
            }
        }

        if (game[6])
        {
            if (a == b || a == c)
            {
                result = Math.Max(result, a * 4);
            }
            if (b == c)
            {
                result = Math.Max(result, b * 4);
            }
        }

        if (game[7])
        {
            if (a == b && b == c)
            {
                if (a == 6)
                    result = Math.Max(result, a + b + c + 5 + 5);
                else
                    result = Math.Max(result, a + b + c + 6 + 6);
            }
            else if (a == b)
            {
                result = Math.Max(Math.Max(a * 3 + c * 2, a * 2 + c * 3), result);
            }
            else if (a == c)
            {
                result = Math.Max(Math.Max(a * 3 + b * 2, a * 2 + b * 3), result);
            }
            else if (b == c)
            {
                result = Math.Max(Math.Max(b * 3 + a * 2, b * 2 + a * 3), result);
            }
        }

        if (game[8])
        {
            if (a != b && b != c && a != c && a != 6 && b != 6 && c != 6)
            {
                result = Math.Max(result, 30);
            }
        }
        if (game[9])
        {
            if (a != b && b != c && a != c && a != 1 && b != 1 && c != 1)
            {
                result = Math.Max(result, 30);
            }
        }
        if (game[10])
        {
            if (a == b && b == c)
            {
                result = Math.Max(result, 50);
            }
        }
        if (game[11])
        {
            result = Math.Max(result, a + b + c + 6 + 6);
        }

        sw.WriteLine(result);
    }
}