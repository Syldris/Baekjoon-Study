using System;
public class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        List<int> list = new List<int>();
        
        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n]; 
        arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        foreach (int num in arr)
        {
            if (list.Count == 0 || list[^1] < num)
                list.Add(num);
            else
            {
                int left = 0;
                int right = list.Count - 1;

                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (list[mid] < num)
                        left = mid + 1;
                    else
                        right = mid;
                }
                list[left] = num;
            }
        }
        sw.WriteLine(list.Count());

    }
}
