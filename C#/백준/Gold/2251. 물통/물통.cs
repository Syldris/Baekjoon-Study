#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int A = int.Parse(input[0]);
        int B = int.Parse(input[1]);
        int C = int.Parse(input[2]);

        List<int> result = new List<int>();
        bool[,,] visited = new bool[201, 201, 201];

        Queue<(int a, int b, int c)> queue = new();
        queue.Enqueue((0, 0, C));

        int[] cap = { A, B, C };
        while (queue.Count > 0)
        {
            (int a, int b, int c) = queue.Dequeue();
            if (visited[a,b,c])
            {
                continue;
            }
            visited[a,b,c] = true;
            if (a == 0 && !result.Contains(c))
            {
                result.Add(c);
            }
            for (int from = 0; from < 3; from++)
            {
                for (int to = 0; to < 3; to++)
                {
                    if (from == to)
                        continue;
                    int[] cur = { a, b, c };
                    (cur[from], cur[to]) = pour(cur[from], cur[to], cap[to]);
                    queue.Enqueue((cur[0], cur[1], cur[2]));
                }
            }

        }


        (int m, int s) pour(int main, int sub, int subCap)
        {
            int space = subCap - sub;
            if (space >= main)
            {
                return (0, sub + main);   
            }
            else
            {
                return (main - space, subCap);
            }
        }

        result.Sort();
        sw.Write(String.Join(' ', result));
    }
}