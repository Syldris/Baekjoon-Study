#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int l = int.Parse(inputs[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        PriorityQueue<(int value, int index),int> queue = new();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            int num = arr[i];
            queue.Enqueue((num, i), num);
            while(queue.Peek().index <= i - l)
            {
                queue.Dequeue();
            }
            sb.Append(queue.Peek().value).Append(' ');   
        }
        sw.Write(sb);
    }
}