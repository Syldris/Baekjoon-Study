#nullable disable
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        BigInteger n = BigInteger.Parse(sr.ReadLine());
        bool nie = true;
        for (int i = 2; i <= 10; i++)
        {
            string text = Format(n, i);
            int c = text.Length / 2;

            if (text[..c] == Reverse(text[^c..]))
            {
                sw.WriteLine($"{i} {text}");
                nie = false;
            }
        }

        if (nie)
        {
            sw.Write("NIE");
        }

        string Format(BigInteger n, int digit)
        {
            StringBuilder sb = new StringBuilder();

            while (n != 0)
            {
                sb.Append(n % digit);
                n /= digit;
            }
            return Reverse(sb.ToString());
        }

        string Reverse(string text)
        {
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }
    }
}