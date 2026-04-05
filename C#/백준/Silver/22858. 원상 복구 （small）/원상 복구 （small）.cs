#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] info = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 셔플 정보

        int[] temp = new int[n];

        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // 셔플의 역순
                // 셔플은 D[i]번째 카드를 i번째로 가져온다.
                // 반대로 생각하면 i번째 카드는 원래 D[i]번째 카드였다.

                int pos = info[j] - 1; // 1-index => 0-index
                temp[pos] = arr[j]; // i번째 카드는 => D[i] 번째로 되돌리기
                // temp[j] = arr[pos]; D[i] => i번째로 보냄 (셔플)
            }

            for (int j = 0; j < n; j++)
            {
                arr[j] = temp[j];
            }
        }

        sw.Write(String.Join(' ', arr));
    }
}