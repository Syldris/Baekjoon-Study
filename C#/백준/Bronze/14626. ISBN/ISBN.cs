#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string line = sr.ReadLine();
        int value = 0;
        int lastValue = line[^1] - '0';
        int star = 1;
        for (int i = 0; i < line.Length - 1; i++)
        {
            if(line[i] == '*')
            {
                if(i % 2 == 1)
                    star = 3;
                continue;
            }
            int num = line[i] - '0';

            if (i % 2 == 1)
            {
                value += num * 3;
            }
            else
            {
                value += num;
            }
        }

        for (int i = 0; i <= 9; i++)
        {
            int curValue = value + (i * star);
            if((10 - (curValue % 10)) %10 == lastValue)
            {
                sw.Write(i);
                return;
            }
        }
    }
}