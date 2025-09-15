#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        List<int> resultlist = new List<int>();
        for (int i = 0; i <= n; i++)
        {
            List<int> list = new List<int>();
            int one = n;
            int two = i;
            int value = one - two;
            int cur = 3;
            list.Add(one);
            list.Add(two);
            list.Add(value);
            while (value >= 0)
            {
                one = two;
                two = value;
                value = one - two;
                if (value >= 0)
                {
                    list.Add(value);
                    cur++;
                }
            }
            if (cur > result)
            {
                result = cur;
                resultlist = list.ToList();
            }
        }
        sw.WriteLine(result);
        sw.WriteLine(String.Join(' ', resultlist));
    }
}
