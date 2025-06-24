using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript1
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();
        int count = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            string[] command = Console.ReadLine().Split();
            switch (command[0])
            {
                case "push":
                    queue.Enqueue(int.Parse(command[1]));
                    break;
                case "pop":
                    if(queue.TryDequeue(out int result))
                    {
                        sb.Append(result).Append("\n");
                        break;
                    }
                    else
                    {
                        sb.Append(-1).Append("\n");
                        break;
                    }
                case "size":
                    sb.Append(queue.Count()).Append("\n");
                    break;
                case "empty":
                    if(queue.Count() > 0)
                    {
                        sb.Append(0).Append("\n");
                        break;
                    }
                    sb.Append(1).Append("\n");
                    break;
                case "front":
                    if(queue.TryPeek(out int result2))
                    {
                        sb.Append(result2).Append("\n"); break;
                    }
                    else
                    {
                        sb.Append(-1).Append("\n"); break;
                    }
                case "back":
                    if(queue.Count() > 0)
                    {
                        int[] arr = queue.ToArray();
                        sb.Append(arr[arr.Length - 1]).Append("\n");
                        break;
                    }
                    else
                    {
                        sb.Append(-1).Append("\n");
                        break;
                    }
                default:
                    break;
            }
        }
        Console.WriteLine(sb.ToString());
    }
}