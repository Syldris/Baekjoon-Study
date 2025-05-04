using System;
using System.Text;
using System.IO;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int count = int.Parse(sr.ReadLine());
        int[] arr = new int[10001];

        for (int i = 0; i < count; i++)
        {
            arr[int.Parse(sr.ReadLine())]++;
        }

        for (int i = 0; i <= 10000; i++)
        {
            for (int j = 0; j < arr[i]; j++)
            {
                sw.WriteLine(i);
            }
        }
    }
}
