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

        List<int> listIndex = new List<int>();
        int[] prev = new int[n];
        Array.Fill(prev, -1);

        int index = 0;

        foreach (int num in arr)
        {
            if (list.Count == 0 || list[^1] < num)
            {
                prev[index] = list.Count > 0 ? listIndex[^1] : -1;
                list.Add(num);
                listIndex.Add(index);
            }
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
                prev[index] = left == 0 ? -1 : listIndex[left - 1];
                listIndex[left] = index;
            }
            index++;
        }

        int cur = listIndex[listIndex.Count - 1];
        Stack<int> stack = new Stack<int>();
        while (cur != -1)
        {
            stack.Push(arr[cur]);
            cur = prev[cur];
        }

        sw.WriteLine(list.Count());
        sw.WriteLine(String.Join(" ", stack));
    }
}
