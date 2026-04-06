#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] dp = new int[n]; // 이여붙였을때 최대 갯수

        int maxNum = 1;
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1; // 자기자신만 선택했을때 최소 1개. 

            for (int j = 0; j < i; j++)
            {
                if (arr[j] > arr[i] && dp[j] + 1 > dp[i]) // 이전 값이 현재값보다 커야 이어붙일수있음.
                {
                    dp[i] = dp[j] + 1; // 최대한 길게 이어붙일수 있도록 계산.
                    maxNum = Math.Max(maxNum, dp[i]);
                }
            }
        }

        sw.Write(n - maxNum);
    }
}