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

        int[] arr = new int[28];

        arr[0] = 1;
        for (int i = 1; i <= 27; i++)
        {
            if (i < 15)
                arr[i] = arr[i - 1] + 1;
            else
                arr[i] = arr[i - 1] - 1;
        }
        for (int t = 0; t < testcase; t++)
        {
            int num = 0b0000;
            int value = int.Parse(sr.ReadLine());
            num += arr[(value - 1) % 28];

            StringBuilder sb = new StringBuilder();
            for (int i = 3; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                if (bit == 1)
                {
                    sb.Append("딸기");
                }
                else
                {
                    sb.Append('V');
                }
            }
            Console.WriteLine(sb);
        }
    }
}
