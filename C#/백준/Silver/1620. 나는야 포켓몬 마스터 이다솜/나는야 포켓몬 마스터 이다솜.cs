using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);
        Dictionary<int, string> map = new Dictionary<int, string>();
        Dictionary<string, int> map2 = new Dictionary<string, int>();
        for (int i = 1; i <= m; i++)
        {
            string read = Console.ReadLine();
            map.Add(i, read);
            map2.Add(read, i);
        }

        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < n; i++)
        {
            string text = Console.ReadLine();
            if(int.TryParse(text, out int key))
            {
                sb.AppendLine(map[key]);
            }
            else
            {
                sb.AppendLine(map2[text].ToString());
            }
        }
        Console.WriteLine(sb);
    }
}
