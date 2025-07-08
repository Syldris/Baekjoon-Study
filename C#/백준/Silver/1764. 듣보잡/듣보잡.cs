using System;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        Dictionary<string,int> dic = new Dictionary<string,int>();
        List<String> strings = new List<string>();
        for (int i = 0; i < n; i++)
        {
            dic.Add(Console.ReadLine(), 0);
        }
        for (int i = 0; i < m; i++)
        {
            string text = Console.ReadLine();
            if(dic.ContainsKey(text))
            {
                strings.Add(text);
            }
        }
        strings.Sort();
        Console.WriteLine(strings.Count);
        Console.WriteLine(String.Join("\n",strings));
    }
}
