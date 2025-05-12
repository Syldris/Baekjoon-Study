using System;
using System.Text;
public class Program
{
    static void Main()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < 7; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if(num % 2 == 1)
                list.Add(num);
        }

        if (list.Count == 0)
        {
            Console.WriteLine(-1);
            return;
        }

        int totalnum = 0;

        foreach (var item in list)
        {
            totalnum += item;
        }

        Console.WriteLine(totalnum);
        Console.WriteLine(list.Min());
    }
}
