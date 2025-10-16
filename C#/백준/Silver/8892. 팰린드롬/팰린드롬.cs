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

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int size = int.Parse(sr.ReadLine());
            string[] arr = new string[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = sr.ReadLine();
            }

            bool palindrome = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j || palindrome)
                    {
                        continue;
                    }
                    string text = arr[i] + arr[j];
                    if (text == new string(text.Reverse().ToArray()))
                    {
                        sw.WriteLine(text);
                        palindrome = true;
                    }
                }
            }
            if(!palindrome)
                sw.WriteLine(0);
        }
    }
}