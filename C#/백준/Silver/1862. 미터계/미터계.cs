#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int value = 0;
        int multiple = 1;
        while (n >= 10) // n 진법 변환 (9진수)
        {
            int x = n % 10;
            if (x > 4) // 4가 없으니 1 2 3 5 6 7 8 9 이렇게 9진법이니 1개씩 당겨주기.
                x--;

            value += x * multiple;
            multiple *= 9; // 뒷자리부터 앞자리로 갈수록 1배, 9배, 81배

            n /= 10; // 10으로 나누기
        }

        if (n > 4)
            n--;
        value += n * multiple;

        sw.Write(value);
    }
}