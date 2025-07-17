#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int one = 0;
        int two = 0;
        int three = 0;

        for (int i = 0; i < n; i++)
        {
            if (i >= 3)
            {
                if (arr[i - 3] == 1)
                    one--;
                else if (arr[i - 3] == 2)
                    two--;
                else
                    three--;
            }
            if (arr[i] == 1)
                one++;
            else if (arr[i] == 2)
                two++;
            else
                three++;

            if (one > 0 && two > 0 && three > 0)
            {
                sw.Write("TAK");
                return;
            }
        }
        sw.Write("NIE");
    }
}
