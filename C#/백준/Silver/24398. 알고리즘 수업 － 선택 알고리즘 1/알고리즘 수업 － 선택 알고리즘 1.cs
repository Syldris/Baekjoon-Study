#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int swap = 0;
        (int i, int j) result = (-1, -1);

        Select(0, n - 1, q);

        if (result.i == -1 && result.j == -1)
        {
            sw.Write(-1);
            return;
        }

        result = result.i <= result.j ? (result.i, result.j) : (result.j, result.i);

        sw.Write($"{result.i} {result.j}");

        int Select(int start, int end, int q)
        {
            if (start == end)
            {
                return arr[start];
            }

            int t = Partition(start, end);
            int k = t - start + 1;

            if (q == k)
            {
                return arr[t];
            }
            else if (q < k)
            {
                return Select(start, t - 1, q);
            }
            else
            {
                return Select(t + 1, end, q - k);
            }

        }

        int Partition(int start, int end)
        {
            int pivot = arr[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    swap++;
                    if (swap == k)
                    {
                        result = (arr[i], arr[j]);
                    }
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            if (i + 1 != end)
            {
                swap++;
                if (swap == k)
                {
                    result = (arr[i + 1], arr[end]);
                }
                (arr[i + 1], arr[end]) = (arr[end], arr[i + 1]);
            }

            return i + 1;
        }
    }
}