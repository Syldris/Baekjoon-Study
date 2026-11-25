#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = line[0];
            int b = line[1];

            sw.WriteLine(BFS(a, b));
        }

        int BFS(int start, int end)
        {
            Queue<(int score, int move, int dangerKick)> queue = new();

            queue.Enqueue((start, 0, 0));

            while (queue.Count > 0)
            {
                (int score, int move, int dangerKick) = queue.Dequeue();

                int target = end + dangerKick * 3;
                if (score == target)
                    return move;

                // 3점추가로 인해 목표점수가 초기점수 100점을 넘을수있으니 150으로 잡자.(최대 2^7 = 128, 상대 +21점)
                if (score * 2 <= 150) // 위험한 킥. 점수 2배되지만 상대 +3점. 
                {
                    queue.Enqueue((score * 2, move + 1, dangerKick + 1));
                }

                if (score + 1 <= 150)
                {
                    queue.Enqueue((score + 1, move + 1, dangerKick));
                }
            }
            return -1;
        }
    }
}