#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int value = int.Parse(sr.ReadLine());
            sw.WriteLine(NumCheck(value) ? 1 : 0);
        }

        bool NumCheck(int value)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 2; i <= 64; i++)
            {
                int n = value;

                while (n != 0)
                {
                    sb.Append((char)(n % i)); // 진법구하기 = i진법으로 나누고 남은수를 세본다.
                    n /= i;
                }

                string text = sb.ToString(); // 순서상 반대가 맞는데 회문체크라 상관없을듯 10 = 0101(뒤집어야함)
                int half = text.Length / 2;
                bool pallndrome = true;
                for (int j = 0; j < half; j++)
                {
                    if (sb[j] != sb[^(j + 1)])
                    {
                        pallndrome = false;
                        break;
                    }
                }
                sb.Clear();

                if (pallndrome)
                    return true;
            }

            return false;
        }

    }
}