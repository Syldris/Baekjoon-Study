using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if(i % 10 == 0 && i != 0)
                sb.AppendLine();
            sb.Append(text[i]);
        }
        Console.WriteLine(sb);
    }
}
