#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        bool[] arr = new bool[5];
        foreach (var item in text)
        {
            switch (item)
            {
                case 'M':
                    arr[0] = true; break;
                case 'O':
                    arr[1] = true; break;
                case 'I':
                    arr[2] = true; break;
                case 'S':
                    arr[3] = true; break;
                case 'B':
                    arr[4] = true; break;
            }
        }

        sw.Write(arr.All(x => x) ? "YES" : "NO");
    }
}
