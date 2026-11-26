#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int start = 0, end = 0;

        int gcd = 0;
        int prev = 0;

        for (int i = 0; i < n; i++)
        {
            int distance = int.Parse(sr.ReadLine());

            if (i == 0) // 시작점 기록.
                start = distance;

            if (i == n - 1) // 끝점 기록.
                end = distance;

            if (i > 0)
            {
                if (gcd == 0) // gcd 첫기록. 가로수 사이의 거리를 기록.
                    gcd = distance - prev;
                else
                    gcd = GCD(gcd, distance - prev); // GCD와 현재 가로수 사이 거리 gcd 최대공약수 계산. 

            }

            prev = distance;
        }
        int totalDistance = end - start;

        // (총거리 / 간격) + 1개 만큼 있으면 정확히 다 깔수있음.(n개는 미리 설치됨)
        sw.Write((totalDistance / gcd) - n + 1);

        int GCD(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
    }
}