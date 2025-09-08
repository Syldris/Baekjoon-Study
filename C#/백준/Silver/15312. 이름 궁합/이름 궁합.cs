#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] alphabet = new int[] { 3, 2, 1, 2, 3, 3, 2, 3, 3, 2, 2, 1, 2, 2, 1, 2, 2, 2, 1, 2, 1, 1, 1, 2, 2, 1 };
        string a = sr.ReadLine();
        string b = sr.ReadLine();
        int[] arr = new int[a.Length * 2];
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = alphabet[a[i / 2] - 'A'];
            }
            else
            {
                arr[i] = alphabet[b[i / 2] - 'A'];
            }
        }
        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                arr[j] = (arr[j] + arr[j + 1]) % 10;
            }
        }
        sw.Write(arr[0]);
        sw.Write(arr[1]);
    }
}
