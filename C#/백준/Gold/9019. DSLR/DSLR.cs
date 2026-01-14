#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int testcase = int.Parse(sr.ReadLine());

        bool[] visited = new bool[10001];
        int[] prev = new int[10001];
        char[] command = new char[10001];

        for (int t = 0; t < testcase; t++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int start = line[0];
            int end = line[1];

            BFS(start, end);
            sw.WriteLine(BackTrack(start, end));
            Reset();
        }


        void BFS(int start, int end)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            visited[start] = true;

            while (queue.Count > 0)
            {
                int value = queue.Dequeue();
                if (value == end) break;

                int digit1 = value / 1000;
                int digit2 = (value / 100) % 10;
                int digit3 = (value / 10) % 10;
                int digit4 = value % 10;

                int valueD = (value * 2) % 10000;
                int valueS = (value != 0) ? value - 1 : 9999;
                int valueL = digit2 * 1000 + digit3 * 100 + digit4 * 10 + digit1;
                int valueR = digit4 * 1000 + digit1 * 100 + digit2 * 10 + digit3;

                QueueInsert(valueD, value, 'D', queue);
                QueueInsert(valueS, value, 'S', queue);
                QueueInsert(valueL, value, 'L', queue);
                QueueInsert(valueR, value, 'R', queue);
            }
        }

        void QueueInsert(int value, int prevValue, char c, Queue<int> queue)
        {
            if (!visited[value])
            {
                visited[value] = true;
                prev[value] = prevValue;
                command[value] = c;
                queue.Enqueue(value);
            }
        }

        string BackTrack(int start, int end)
        {
            int len = 0;
            for (int i = end; i != start; i = prev[i])
            {
                len++;
            }

            char[] result = new char[len];
            int index = len;
            for (int i = end; i != start; i = prev[i])
            {
                result[--index] = command[i];
            }

            return new string(result);
        }

        void Reset()
        {
            for (int i = 0; i <= 10000; i++)
            {
                visited[i] = false;
                prev[i] = -1;
                command[i] = ' ';
            }
        }
    }
}