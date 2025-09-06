#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string a = sr.ReadLine();
        string b = sr.ReadLine();

        StringBuilder astring = new StringBuilder();
        StringBuilder bstring = new StringBuilder();
        while (astring.Length != a.Length * b.Length)
        {
            astring.Append(a);
        }
        while (bstring.Length != a.Length * b.Length)
        {
            bstring.Append(b);
        }
        sw.Write(astring.ToString() == bstring.ToString() ? 1 : 0);
    }
}
