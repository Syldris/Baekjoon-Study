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

        int n = int.Parse(sr.ReadLine());
        string line = sr.ReadLine();
        int bonus = 0;
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            if (line[i-1] == 'O')
            {
                result += i;
                result += bonus++;
            }
            else
            {
                bonus = 0;
            }
        }
        sw.Write(result);
    }
}
