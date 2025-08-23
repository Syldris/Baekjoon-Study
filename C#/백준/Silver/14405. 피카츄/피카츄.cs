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
        int mode = 0;
        bool pikachu = true;
        foreach (var item in text)
        {
            if(!pikachu) break;
            if (mode == 0)
            {
                switch (item)
                {
                    case 'p':
                        mode = 1; break;
                    case 'k':
                        mode = 2; break;
                    case 'c':
                        mode = 3; break;
                    default:
                        pikachu = false; break;
                }
            }
            else
            {
                switch (mode)
                {
                    case 1:
                        if (item == 'i') mode = 0;
                        else pikachu = false; break;
                    case 2:
                        if (item == 'a') mode = 0;
                        else pikachu = false; break;
                    case 3:
                        if (item == 'h') mode = 4;
                        else pikachu = false; break;
                    case 4:
                        if (item == 'u') mode = 0;
                        else pikachu = false; break;
                }
            }
        }
        sw.Write(pikachu && mode == 0 ? "YES" : "NO");
    }
}
