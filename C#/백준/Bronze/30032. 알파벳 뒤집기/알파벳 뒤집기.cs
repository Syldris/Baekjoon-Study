#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int dir = int.Parse(input[1]);
        for (int i = 0; i < n; i++)
        {
            string text = sr.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (var item in text)
            {
                sb.Append(change(item));
            }
            sw.WriteLine(sb);
        }
        char change(char c)
        {
            if (dir == 1)
            {
                switch (c)
                {
                    case 'd':
                        return 'q';
                    case 'b':
                        return 'p';
                    case 'q':
                        return 'd';
                    case 'p':
                        return 'b';
                }
            }
            else
            {
                switch (c)
                {
                    case 'd':
                        return 'b';
                    case 'b':
                        return 'd';
                    case 'q':
                        return 'p';
                    case 'p':
                        return 'q';
                }
            }
            return ' ';
        }
    }
}