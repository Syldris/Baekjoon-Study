#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        PriorityQueue<(int value, int index), int> queue = new();
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
            queue.Enqueue((arr[i], i), -arr[i]);
        }

        int result = 0;

        while (true)
        {
            (int value, int index) = queue.Dequeue();
            if (index != 0)
            {
                if (value < arr[0]) continue; 

                result++;

                arr[0]++;
                arr[index]--;
                queue.Enqueue((arr[index], index), -arr[index]);
            }
            else
            {
                if (equalCheck()) result++;
                sw.Write(result);
                return;
            }
        }


        bool equalCheck()
        {
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[0])
                    return true;
            }
            return false;
        }
    }
}