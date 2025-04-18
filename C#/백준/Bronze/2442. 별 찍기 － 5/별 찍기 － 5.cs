using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript1
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= n; i++)
        {
            sb.Append(new string(' ', n - i));
            sb.Append(new string('*', i * 2 - 1));
            if(i != n)
                sb.AppendLine();
        }
        Console.WriteLine(sb);
    }
}
