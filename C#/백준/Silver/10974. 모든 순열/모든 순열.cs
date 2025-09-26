#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        bool[] visited = new bool[n];
        int[] arr = new int[n];

        DFS(0);

        void DFS(int depth)
        {
            if (depth == n)
            {
                sw.WriteLine(String.Join(' ', arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!visited[i-1])
                {
                    arr[depth] = i;
                    visited[i-1] = true;
                    DFS(depth + 1);
                    visited[i-1] = false;
                }
            }
        }
    }
}
