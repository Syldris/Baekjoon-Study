#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        bool find = false;
        QuickSort(0, n - 1);

        if (!find) sw.Write(-1);

        void QuickSort(int start, int end)
        {
            if (start < end)
            {
                int mid = Partition(start, end); // 정렬된 원소를 기준으로 분할
                if (mid == -1)
                {
                    find = true;
                    return;
                }

                QuickSort(start, mid - 1); // 왼쪽 배열 정렬
                QuickSort(mid + 1, end); // 오른쪽 배열 정렬
            }
        }

        int Partition(int start, int end)
        {
            int x = arr[end]; // 기준 원소
            int i = start - 1; // 교체 시작점 (i의 원소는 <= x 를 만족)

            for (int j = start; j < end; j++)
            {
                if (arr[j] <= x) // start => end 까지 x 와 비교하며  ++i위치에 j와 스왑하여 정렬
                {
                    k--;
                    if (k == 0)
                    {
                        sw.Write(arr[++i] < arr[j] ? $"{arr[i]} {arr[j]}" : $"{arr[j]} {arr[i]}");
                        return -1;
                    }
                    (arr[++i], arr[j]) = (arr[j], arr[i]);
                }
            }

            if (i + 1 != end) // 전부 정렬 된게 아니라면 마지막 원소 또한 스왑 (i+1은 스왑되지 않은 원소로 end 보다 큼)
            {
                k--;
                if (k == 0)
                {
                    sw.Write(arr[i + 1] < arr[end] ? $"{arr[i + 1]} {arr[end]}" : $"{arr[end]} {arr[i + 1]}");
                    return -1;
                }
                (arr[i + 1], arr[end]) = (arr[end], arr[i + 1]);
            }
            return i + 1;
        }

    }
}