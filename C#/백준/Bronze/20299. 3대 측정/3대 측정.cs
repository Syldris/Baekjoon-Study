#nullable disable
using System;
using System.Net.Sockets;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int l = int.Parse(input[2]);
        int result = 0;
        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);
            if (a + b + c >= k && Math.Min(Math.Min(a, b), c) >= l)
            {
                result++;
                list.Add(a);
                list.Add(b);
                list.Add(c);
            }
        }
        sw.WriteLine(result);
        sw.WriteLine(string.Join(' ', list));
    }
}
