using System;
using System.Text;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int money = 0;
        for (int i = 0; i < n; i++)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            switch(line[0])
            {
                case 136: money += 1000; break;
                case 142: money += 5000; break;
                case 148: money += 10000; break;
                case 154: money += 50000; break;
            }
        }
        Console.WriteLine(money);
    }
}
