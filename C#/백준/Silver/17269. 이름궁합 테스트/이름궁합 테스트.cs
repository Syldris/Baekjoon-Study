#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] alphabet = new int[] { 3, 2, 1, 2, 4, 3, 1, 3, 1, 1, 3, 1, 3, 2, 1, 2, 2, 2, 1, 2, 1, 1, 1, 2, 2, 1 };

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        
        string[] strings = sr.ReadLine().Split();
        string textA = strings[0];
        string textB = strings[1];
        
        int[] arr = new int[a + b];
        int aidx = 0, bidx = 0;

        bool order = true;
        for (int i = 0; i < arr.Length; i++)
        {
            if (order)
            {
                if (aidx < a)
                    arr[i] = alphabet[textA[aidx++] - 'A'];
                else
                    arr[i] = alphabet[textB[bidx++] - 'A'];
                order = false;
            }
            else
            {
                if (bidx < b)
                    arr[i] = alphabet[textB[bidx++] - 'A'];
                else
                    arr[i] = alphabet[textA[aidx++] - 'A'];
                order = true;
            }
        }
        for (int i = 0; i < a + b - 2; i++)
        {
            for (int j = a + b - 1; j > i; j--)
            {
                arr[j] = (arr[j] + arr[j - 1]) % 10; 
            }
        }
        sw.WriteLine(arr[^2] == 0 ? $"{arr[^1]}%" : $"{arr[^2]}{arr[^1]}%");
    }
}
