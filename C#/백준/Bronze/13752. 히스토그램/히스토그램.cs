using System;
using System.Text;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(Console.ReadLine());
            for(int j = 0; j < value; j++)
            {
                sb.Append('=');
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}
