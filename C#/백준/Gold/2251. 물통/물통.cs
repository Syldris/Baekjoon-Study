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

            var ab = pour(a, b, B);
            queue.Enqueue((ab.m, ab.s, c));

            var ac = pour(a, c, C);
            queue.Enqueue((ac.m, b, ac.s));

            var ba = pour(b, a, A);
            queue.Enqueue((ba.s, ba.m, c));

            var bc = pour(b, c, C);
            queue.Enqueue((a, bc.m, bc.s));

            var ca = pour(c, a, A);
            queue.Enqueue((ca.s, b, ca.m));

            var cb = pour(c, b, B);
            queue.Enqueue((a, cb.s, cb.m));

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