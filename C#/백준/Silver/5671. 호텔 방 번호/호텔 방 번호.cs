#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string input = sr.ReadLine();
            if(input == null)
                break;
            string[] line = input.Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            int result = 0;
            for (int i = a; i <= b; i++)
            {
                List<char> list = new List<char>();
                string text = i.ToString();
                bool plus = true;
                foreach (var item in text)
                {
                    if (list.Contains(item))
                    {
                        plus = false;
                        break;
                    }
                    list.Add(item);
                }
                result += plus ? 1 : 0;
            }
            sw.WriteLine(result);
        }
    }
}
