#nullable disable
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());


        for (int t = 0; t < testcase; t++)
        {
            string[] line = sr.ReadLine().Split();

            int m = int.Parse(line[0]);

            if (m == 1)
            {
                int[] arr = line[1].Split('.').Select(int.Parse).Reverse().ToArray();
                ulong result = 0;

                for (int i = 0; i < 8; i++)
                {
                    result |= (ulong)arr[i] << (i * 8);
                }
                sw.WriteLine(result);
            }
            else
            {
                ulong value = ulong.Parse(line[1]);
                int[] result = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    int bit = (int)(value >> (i * 8) & 0b11111111);
                    result[7 - i] = bit;
                }
                sw.WriteLine(String.Join('.', result));
            }
        }
    }
}