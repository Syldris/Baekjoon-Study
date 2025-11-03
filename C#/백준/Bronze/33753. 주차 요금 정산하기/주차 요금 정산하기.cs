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
        int c = int.Parse(input[2]);

        int time = int.Parse(sr.ReadLine());
        int result = a;

        if (time > 30)
        {
            time -= 30;
            int value = time / b;
            if (time % b != 0)
                value++;
            result += value * c;
        }
        sw.Write(result);
    }
}