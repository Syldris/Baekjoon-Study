using System;
using System.Text;
using System.IO;
public class Program
{
    static void Main()
    {
        int[] arr = new int[5];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int value = 0;
        foreach (var item in arr)
        {
            value += item;
        }
        Array.Sort(arr);
        arr = arr.Skip(2).ToArray();
        Console.WriteLine(value / 5);
        Console.WriteLine(arr[0]);
    }
}
