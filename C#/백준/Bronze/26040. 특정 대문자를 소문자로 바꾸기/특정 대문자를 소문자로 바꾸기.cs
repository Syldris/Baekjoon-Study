#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        StringBuilder sb = new StringBuilder();
        string line = sr.ReadLine();
        string[] letter = sr.ReadLine().Split(' ');
        HashSet<char> hash = new HashSet<char>();

        foreach (var item in letter)
        {
            hash.Add(item[0]);
        }

        foreach (char c in line)
        {
            if (hash.Contains(c))
            {
                sb.Append(char.ToLower(c));
            }
            else
            {
                sb.Append(c);
            }
        }
        sw.Write(sb);
    }
}
