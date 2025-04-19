using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        char[,] arr = new char[15, 5];

        for (int y = 0; y < 5; y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < line.Length; x++)
            {
                arr[x, y] = line[x];
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int x = 0; x < 15; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (arr[x,y] != '\0')
                    sb.Append(arr[x, y]);
            }
        }
        Console.WriteLine(sb);
    }
}
