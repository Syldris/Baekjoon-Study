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
            string line = sr.ReadLine();
            int size = int.Parse(sr.ReadLine());
            int[] arr = new int[size];
            string input = sr.ReadLine().Trim('[', ']');

            if (input != "")
            {
                arr = Array.ConvertAll(input.Split(','), int.Parse);
            }

            int start = 0;
            int end = 1;
            bool reverse = false;

            foreach (var item in line)
            {
                if (item == 'R')
                {
                    reverse = !reverse;
                }
                else
                {
                    size--;
                    if (size < 0)
                    {
                        break;
                    }
                    if (reverse)
                    {
                        arr[^end++] = 0;
                    }
                    else
                    {
                        arr[start++] = 0;
                    }
                }
            }

            if (size < 0)
            {
                sw.WriteLine("error");
                continue;
            }

            if(reverse)
                arr = arr.Where(x => x != 0).Reverse().ToArray();
            else
                arr = arr.Where(x => x != 0).ToArray();

            sw.WriteLine($"[{String.Join(',', arr)}]");
        }

    }
}
