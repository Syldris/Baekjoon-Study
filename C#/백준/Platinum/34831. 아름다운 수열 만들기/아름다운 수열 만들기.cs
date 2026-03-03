#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] value = new int[3];
        int[] arr = new int[6];
        bool find = false;

        int[] zeroStartTwoEnd = new int[6]; // 0 to 2로 가는 6길이 배열
        int[] twoStartZeroEnd = new int[6]; // 2 to 0으로 가는 6길이 배열 

        arr[0] = 0;
        BackTrack(0, 1, zeroStartTwoEnd);

        Array.Clear(arr);
        Array.Clear(value);
        find = false;

        arr[0] = 2;
        BackTrack(2, 1, twoStartZeroEnd);

        int[] result = new int[10]; // 백트래킹 결과상  0 to 2 to 0 이 가능해보인다.

        /* 0 to 2를 6개 다담고 , 2 to 0 은 2 넘기고 0직전까지만 담으면 되니 2| x x x x |0 4개 담으면 될거같다.
           0으로 시작하고 난뒤 10주기 순환을 하며 5개로 끊길때도 조건을 만족 하는것 같다.*/

        for (int i = 0; i < 6; i++)
            result[i] = zeroStartTwoEnd[i];

        for (int i = 6; i < 10; i++)
            result[i] = twoStartZeroEnd[i - 5];

        int n = int.Parse(sr.ReadLine());
        if (n % 5 != 1)
        {
            sw.Write("No");
            return;
        }

        sw.WriteLine("Yes");
        for (int i = 0; i < n; i++)
        {
            sw.Write($"{result[i % 10]} ");
        }

        void BackTrack(int node, int depth, int[] array) // 백트래킹 결과 n = 6,11,16,21,26,31 에서 성립(x*5+1)모양. value는 각각 4,8,12,16,20,24 (x * 4)모양이다.
        {
            if (find == true) return;

            if (depth == 6)
            {
                bool option = (arr[0] == 0 && arr[^1] == 2) || (arr[0] == 2 && arr[^1] == 0); // 0 to 2 나 2 to 0 배열만 구해보자.
                if (value[0] == value[1] && value[1] == value[2] && option)
                {
                    Array.Copy(arr, array, 6);
                    find = true;
                }
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if (i == node) continue;

                arr[depth] = i;

                value[node] += Math.Abs(i - node);
                value[i] += Math.Abs(i - node);

                BackTrack(i, depth + 1, array);

                value[node] -= Math.Abs(i - node);
                value[i] -= Math.Abs(i - node);
            }
        }
    }
}