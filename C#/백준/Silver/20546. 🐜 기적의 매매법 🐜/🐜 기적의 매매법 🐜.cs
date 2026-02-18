#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int aMoney = n;
        int aStock = 0;
        foreach (var item in arr)
        {
            // 살수있으면 전부 다삼
            if (aMoney >= item)
            {
                int value = aMoney / item;
                aMoney -= value * item;
                aStock += value;
            }
        }

        int bMoney = n;
        int bStock = 0;
        int upCount = 0;
        int downCount = 0;
        int prev = int.MinValue;

        foreach (var item in arr)
        {
            // 전 가격 비교
            if (prev != int.MinValue)
            {
                if (item > prev)
                {
                    upCount++;
                    downCount = 0;
                }
                else if (item < prev)
                {
                    upCount = 0;
                    downCount++;
                }
                else
                {
                    upCount = 0;
                    downCount = 0;
                }
            }

            // 3일 오르면 청산
            if (upCount >= 3)
            {
                bMoney += bStock * item;
                bStock = 0;
            }
            
            // 3일 내리면 매입
            if (downCount >= 3)
            {
                int value = bMoney / item;
                bMoney -= value * item;
                bStock += value;
            }

            prev = item;
        }

        if (aStock * arr[^1] + aMoney == bStock * arr[^1] + bMoney)
        {
            sw.Write("SAMESAME");
        }
        else if (aStock * arr[^1] + aMoney > bStock * arr[^1] + bMoney)
        {
            sw.Write("BNP");
        }
        else
        {
            sw.Write("TIMING");
        }
    }
}