#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        int uc = 0;
        int dp = 0;;
        foreach (var item in text)
        {
            switch (item)
            {
                case 'U':
                    uc++; break;
                case 'D':
                    dp++; break;
                case 'P':
                    dp++; break;
                case 'C':
                    uc++; break;
            }
        }
        if (uc > (dp) / 2 +(dp) % 2 )
        {
            sw.Write('U');
        }
        if (dp > 0)
        {
            sw.Write("DP");
        }
    }
}
