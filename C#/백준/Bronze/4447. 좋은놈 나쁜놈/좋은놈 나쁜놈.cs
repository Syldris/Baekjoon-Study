#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            int g = 0;
            int b = 0;
            string text = sr.ReadLine();
            foreach (var item in text)
            {
                if (item == 'g' || item == 'G')
                {
                    g++;
                }
                else if (item == 'b' || item == 'B')
                {
                    b++;
                }
            }

            if (g > b)
            {
                sw.WriteLine($"{text} is GOOD");
            }
            else if (b > g)
            {
                sw.WriteLine($"{text} is A BADDY");
            }
            else
            {
                sw.WriteLine($"{text} is NEUTRAL");
            }
        }
    }
}