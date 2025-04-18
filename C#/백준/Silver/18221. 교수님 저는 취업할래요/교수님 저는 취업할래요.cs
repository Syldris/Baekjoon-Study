using System;
using System.Collections;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];

        (int x, int y) drPos = (0, 0);
        (int x, int y) myPos = (0, 0);

        for (int y = 0; y < n; y++)
        {
            string[] line = Console.ReadLine().Split();
            for (int x = 0; x < n; x++)
            {
                int number = int.Parse(line[x]);
                arr[x,y] = number;
                if(number == 5)
                    drPos = (x,y);
                if(number == 2)
                    myPos = (x,y);
            }
        }
        
        int count = 0;
        int minX = 0, maxX = 0;
        int minY = 0, maxY = 0;
        if(drPos.x >= myPos.x)
        {
            minX = myPos.x;
            maxX = drPos.x;
        }
        else
        {
            minX = drPos.x;
            maxX = myPos.x;
        }

        if(drPos.y >= myPos.y)
        {
            minY = myPos.y;
            maxY = drPos.y;
        }
        else
        {
            minY = drPos.y;
            maxY = myPos.y;
        }

        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                if (arr[x, y] == 1)
                    count++;
            }
        }

        int dist = (int)Math.Pow((maxX - minX), 2) + (int)Math.Pow((maxY - minY), 2);
        dist = (int)Math.Sqrt(dist);

        Console.WriteLine(count >= 3 && dist >=5 ? 1 : 0);
    }
}
