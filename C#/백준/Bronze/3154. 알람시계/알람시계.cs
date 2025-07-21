#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        string[] input = sr.ReadLine().Split(':');
        int hour = int.Parse(input[0]);
        int minute = int.Parse(input[1]);
        int result = int.MaxValue;
        (int x, int y)[] arr = new (int x, int y)[] {(1, 3), (0, 0), (1, 0), (2, 0), (0, 1), (1, 1), (2, 1), (0, 2), (1, 2), (2, 2)};
        
        int resulth = 0;
        int resultm = 0;

        for (int h1 = 0; h1 <= 9; h1++)
        {
            for (int h2 = 0; h2 <= 9; h2++)
            {
                for (int m1 = 0; m1 <= 9; m1++)
                {
                    for (int m2 = 0; m2 <= 9; m2++)
                    {
                        int curhour = h1 * 10 + h2;
                        int curminute = m1 * 10 + m2;
                        if (curhour % 24 == hour && curminute % 60 == minute)
                        {
                            int curresult = Math.Abs(arr[h1].x - arr[h2].x) + Math.Abs(arr[h1].y - arr[h2].y) +
                                            Math.Abs(arr[h2].x - arr[m1].x) + Math.Abs(arr[h2].y - arr[m1].y) +
                                            Math.Abs(arr[m1].x - arr[m2].x) + Math.Abs(arr[m1].y - arr[m2].y);
                            if (curresult < result)
                            {
                                result = curresult;
                                resulth = curhour;
                                resultm = curminute;
                            }
                        }
                    }
                }
            }
        }
        sw.Write($"{resulth:D2}:{resultm:D2}");
    }
}
