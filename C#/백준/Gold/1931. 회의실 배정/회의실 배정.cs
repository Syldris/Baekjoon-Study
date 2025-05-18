using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        (int starttime, int endtime)[] arr = new (int, int)[n];

        for (int i = 0; i < n; i++)
        {
            string[] inputs = sr.ReadLine().Split();
            int start = int.Parse(inputs[0]);
            int end = int.Parse(inputs[1]);
            arr[i] = (start, end);
        }
        
        arr = arr.OrderBy(x => x.endtime).ThenBy(x => x.starttime).ToArray();

        int curtime = 0;
        int count = 0;
        foreach (var item in arr)
        {
            if(item.starttime >= curtime)
            {
                count++;
                curtime = item.endtime;
            }
        }
        sw.WriteLine(count);
    }
}
