#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(),int.Parse);
        long speed = arr[^1];

        for (int i = n-1; i >= 0; i--)
        {
            if (arr[i] >= speed)
            {
                speed = arr[i];
            }
            else if(speed % arr[i] != 0)
            {
                long value = (speed / arr[i]) + 1;
                speed = arr[i] * value;
            }
        }
        sw.Write(speed);

    }
}
