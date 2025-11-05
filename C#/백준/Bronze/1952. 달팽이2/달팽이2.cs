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
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);

        int result = 0;
        bool turn = true;
        while (true)
        {
            if (turn)
            {
                a--;
                if (a == 0)
                    break;
            }
            else
            {
                b--;
                if (b == 0)
                    break;
            }
            turn = !turn;
            result++;
        }

        sw.Write(result);
    }

}