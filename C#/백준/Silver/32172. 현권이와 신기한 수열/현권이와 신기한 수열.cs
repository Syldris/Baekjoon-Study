#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        HashSet<int> hash = new HashSet<int>();
        hash.Add(0);
        int prev = 0;
        int result = 0;

        for (int i = 0; i <= n; i++)
        {
            result = prev - i;
            if (result < 0 || hash.Contains(result))
            {
                result = prev + i;
            }
            hash.Add(result);
            prev = result;
        }

        sw.WriteLine(result);
    }
}