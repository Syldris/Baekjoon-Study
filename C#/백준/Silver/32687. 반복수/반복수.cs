#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        long[] split = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        long a = split[0];
        long b = split[1];
        long k = split[2];
        long m = split[3];

        int answer = 0;

        int start = (int)Math.Pow(10, k - 1); // k자릿수 시작.
        int end = (int)Math.Pow(10, k); // k자리수 끝.

        for (int i = start; i < end; i++)
        {
            long value = i;
            string text = i.ToString();

            int order = 0;

            while (value <= b)
            {
                if (a <= value && value <= b && value % m == 0) // a 와 b 사이중 m으로 나누어 떨어질때 값증가.
                    answer++;

                value *= 10;  // 자릿수 늘리고 
                value += text[order % text.Length] - '0'; // i의 첫자릿수부터 순서대로 뒤에 붙임.
                order++; 
            }
        }

        sw.Write(answer);
    }
}