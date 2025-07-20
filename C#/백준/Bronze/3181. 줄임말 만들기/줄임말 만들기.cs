#nullable disable
using System;
using System.Linq;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        string[] strings = new string[] { "i", "pa", "te", "ni", "niti", "a", "ali", "nego", "no", "ili" };
        string[] line = sr.ReadLine().Split();
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach (var item in line)
        {
            if (!strings.Contains(item) || count == 0)
            {
                sb.Append(item.ToUpper()[0]);
            }
            count++;
        }
        sw.Write(sb);
    }
}
