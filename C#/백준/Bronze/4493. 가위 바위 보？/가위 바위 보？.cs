#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());

            int player1 = 0;
            int player2 = 0;

            for (int i = 0; i < n; i++)
            {
                string[] line = sr.ReadLine().Split();
                int a = Sign(line[0]);
                int b = Sign(line[1]);
                if ((a + 1) % 3 == b)
                {
                    player2++;
                }
                else if ((b + 1) % 3 == a)
                {
                    player1++;
                }
            }
            sw.WriteLine(player1 == player2 ? "TIE" : player1 > player2 ? "Player 1" : "Player 2"); 
        }

        int Sign(string text)
        {
            if (text == "R")
                return 0;
            else if (text == "P")
                return 1;
            else
                return 2;
        }
    }
}
