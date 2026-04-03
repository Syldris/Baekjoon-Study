#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = Read();
        int[] arr = new int[n];
        for(int i = 0; i < n; i++)
            arr[i] = Read();

        long curPower = arr[0];

        arr[0] = 0; // 0으로 만들기
        Array.Sort(arr);

        for (int i = 1; i < n; i++)
        {
            if (curPower > arr[i])
            {
                curPower += arr[i];
            }
            else
            {
                sw.Write("No");
                return;
            }
        }

        sw.Write("Yes");

        int Read()
        {
            int c = sr.Read();

            while (c != '-' && (c < '0' || c > '9'))
                c = sr.Read();

            bool minus = false;
            int value = 0;

            if (c == '-')
            {
                minus = true;
                c = sr.Read();
            }

            while ('0' <= c && c <= '9')
            {
                value *= 10;
                value += c - '0';
                c = sr.Read();
            }

            return minus ? -value : value;
        }
    }
}