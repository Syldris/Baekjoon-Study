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

        while (true)
        {
            string line = sr.ReadLine();
            if(line == null)
                break;
            int[] arr = line.Split(' ',StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();

            bool[] prev = new bool[arr.Length + 1];
            bool jolly = true;
            for (int i = 1; i < arr.Length; i++)
            {
                int value = Math.Abs(arr[i] - arr[i - 1]);
                if (value >= arr.Length)
                {
                    jolly = false;
                    break;
                }

                if (!prev[value])
                {
                    prev[value] = true;
                }
                else
                {
                    jolly = false;
                    break;
                }
            }
            for (int i = 1; i < arr.Length; i++)
            {
                if (!prev[i])
                {
                    jolly = false;
                    break;
                }
            }
            sw.WriteLine(jolly ? "Jolly" : "Not jolly");
        }
    }
}
