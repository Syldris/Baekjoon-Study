#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] promises = { "Never gonna give you up", "Never gonna let you down", "Never gonna run around and desert you", "Never gonna make you cry", "Never gonna say goodbye", "Never gonna tell a lie and hurt you", "Never gonna stop" };

        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            bool promise = false;
            foreach (var item in promises)
            {
                if (item == line)
                {
                    promise = true;
                }
            }
            if (!promise)
            {
                sw.Write("Yes");
                return;
            }
        }
        sw.Write("No");
    }
}
