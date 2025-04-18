using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split('-');
        char[] arr = new char[inputs.Length];
        for (int i = 0; i < inputs.Length; i++)
        {
            arr[i] = inputs[i][0];
        }
        foreach (var item in arr)
        {
            Console.Write(item);
        }
    }
}
