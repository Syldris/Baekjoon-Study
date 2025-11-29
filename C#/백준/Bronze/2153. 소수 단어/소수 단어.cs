#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();

        int value = 0;

        foreach (var item in text)
        {
            if ('a' <= item && item <= 'z')
            {
                value += item - 'a' + 1;
            }
            else
            {
                value += item - 'A' + 27;
            }
        }
        sw.Write(IsPrime(value) ? "It is a prime word." : "It is not a prime word.");

        bool IsPrime(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                for (int j = i*i; j <= n; j += i)
                {
                    if (n % j == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}