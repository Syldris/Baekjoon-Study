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

        string[] firstline = sr.ReadLine().Split();
        int n = int.Parse(firstline[0]);
        double value = double.Parse(firstline[1]);

        while (true)
        {
            string line = sr.ReadLine();
            if(line == null) 
                break;
            line = line.Trim();
            string[] info = line.Split();
            int team = int.Parse(info[0]);

            int totalsecond = 0;
            bool disque = false;
            for (int i = 1; i <= n; i++)
            {
                string[] time = info[i].Split(':');
                if(time[0] == "-")
                {
                    disque = true;
                    continue;
                }    
                int hour = int.Parse(time[0]);
                int minute = int.Parse(time[1]);
                int second = int.Parse(time[2]);
                totalsecond += (hour *3600) + (minute *60) + second;
            }
            double result = Math.Round(totalsecond / value);

            if (disque)
                sw.WriteLine($"{team,3}: -");
            else
                sw.WriteLine($"{team,3}: {(int)result/60}:{((int)result%60):D2} min/km");
        }

    }
}
