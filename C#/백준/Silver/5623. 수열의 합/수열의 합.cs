#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] first = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        if (n == 2)
        {
            sw.Write($"{1} {first[1] - 1}");
            return;
        }

        int[] info = new int[n];// 현재수가 첫번째 수 보다 얼마나 큰지 체크
        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (i < n - 1)
            {
                info[i] = line[i + 1] - first[i + 1];
            }
            else
            {
                info[i] = line[i - 1] - first[i - 1];
            }
        }

        int diff = (first[1] - info[1]) / 2; // 차이만 구했으니 보정값. 두수의 합에서 한쪽이 얼마나 큰지 빼고 2로 나누면 됨.
        for (int i = 0; i < n; i++)
        {
            sw.Write($"{info[i] + diff} ");
        }
    }
}