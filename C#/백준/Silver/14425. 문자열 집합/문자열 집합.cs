#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int n = int.Parse(line[0]);
        int m = int.Parse(line[1]);
        HashSet<string> hash = new HashSet<string>();
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            hash.Add(sr.ReadLine());
        }
        for (int i = 0; i < m; i++)
        {
            if (hash.TryGetValue(sr.ReadLine(), out string text))
            {
                result++;
            }
        }
        sw.Write(result);
    }
}
