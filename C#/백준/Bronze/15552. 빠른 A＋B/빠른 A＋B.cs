using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            string[] arr = Console.ReadLine().Split(' ');
            int num = int.Parse(arr[0]) + int.Parse(arr[1]);
            sb.Append(num).Append("\n");
        }
        Console.WriteLine(sb.ToString());
    }
}