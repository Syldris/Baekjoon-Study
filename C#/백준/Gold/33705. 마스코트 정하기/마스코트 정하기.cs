#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] leftDp = new int[n];
        leftDp[0] = arr[0] == 1 ? 1 : 0;

        for (int i = 1; i < n; i++)
        {
            leftDp[i] = leftDp[i - 1];
            if (arr[i] == 1)
                leftDp[i]++;
        }

        int[] rightDp = new int[n]; // 반전해서 생각해야함.
        rightDp[0] = arr[^1] == 1 ? 1 : 0;
        for (int i = 1; i < n; i++)
        {
            rightDp[i] = rightDp[i - 1];
            if (arr[^(i + 1)] == 1)
                rightDp[i]++;
        }


        if (leftDp[^1] >= (n + 1) / 2) // 1번 투표가 과반수인 경우
        {
            sw.Write(0);
            return;
        }

        for (int i = 0; i < n - 1; i++) // 왼쪽 제거
        {
            int leftValue = leftDp[^1] - leftDp[i]; // i 갯수
            int rightValue = rightDp[^1] - rightDp[i];
            int range = n - i - 1; // 현재 투표수

            if (leftValue >= (range + 1) / 2 || rightValue >= (range + 1) / 2) // 1 기준으로 왼쪽|오른쪽 내보냈을때 남은 범위에서 1이 과반수
            {
                sw.Write(1);
                return;
            }
        }

        sw.Write(2); // 어떤 경우에도 1을 포함에서 |왼쪽|1|오른쪽| 이렇게 2번 내쫒으면 됨.
    }
}