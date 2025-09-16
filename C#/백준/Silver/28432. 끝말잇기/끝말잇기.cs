#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] arr = new string[n];
        int pos = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            arr[i] = line;
            if (line == "?")
            {
                pos = i;
            }
        }

        int a = int.Parse(sr.ReadLine());
        string[] text = new string[a];
        for (int i = 0; i < a; i++)
        {
            text[i] = sr.ReadLine();
        }

        if (n == 1)
        {
            sw.Write(text[0]);
            return;
        }


        foreach (var item in text)
        {
            if (arr.Contains(item))
            {
                continue;
            }

            if (pos == 0)
            {
                if (item[^1] == arr[pos+1][0])
                {
                    sw.Write(item);
                    return;
                }
            }
            else if (pos == n - 1)
            {
                if (item[0] == arr[pos-1][^1])
                {
                    sw.Write(item);
                    return;
                }
            }
            else
            {
                if (item[^1] == arr[pos+1][0] && item[0] == arr[pos-1][^1])
                {
                    sw.Write(item);
                    return;
                }
            }
        }
    }
}
