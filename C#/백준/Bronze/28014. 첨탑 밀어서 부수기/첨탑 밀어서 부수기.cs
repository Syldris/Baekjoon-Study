using System;
using System.Text;
using System.IO;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int value = 1;
        int index = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if(arr[index] <= arr[i])
            {
                value++;
            }
            index = i;
        }
        sw.Write(value);
    }
}
