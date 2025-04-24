using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        (int x, int y)[] arr = new (int, int)[n];

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            arr[i] = (x, y);
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            (int x, int y) = arr[i];
            int level = 1;
            for (int j = 0; j < n; j++)
            {
                if (arr[j].x > x && arr[j].y > y)
                    level++;
            }
            sb.Append(level).Append(" ");
        }
        Console.WriteLine(sb);
    }
}
