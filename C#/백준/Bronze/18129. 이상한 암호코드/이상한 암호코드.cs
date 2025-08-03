#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        string line = input[0].ToLower();
        int n = int.Parse(input[1]);
        HashSet<char> hash = new HashSet<char>();

        StringBuilder sb = new StringBuilder();

        int result = 1;

        for (int i = 1; i < line.Length; i++)
        {
            
            if (line[i - 1] != line[i])
            {
                if (!hash.Contains(line[i - 1]))
                {
                    hash.Add(line[i - 1]);
                    sb.Append(result >= n ? '1' : '0');
                    result = 1;
                }
            }
            else
            {
                result++;
            }
        }
        if (!hash.Contains(line[^1]))
            sb.Append(result >= n ? '1' : '0');
        sw.Write(sb);
    }
}
