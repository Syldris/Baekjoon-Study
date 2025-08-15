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
        string result = sr.ReadLine();
        StringBuilder sb = new StringBuilder();
        foreach (var item in text)
        {
            if(!(item >= '0' && item <= '9'))
                sb.Append(item);
        }
        sw.Write(sb.ToString().Contains(result) ? 1 : 0);
    }
}
