
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int value = 0;
        for(int i = 2; i <= n; i++)
        {
            int cur = i;
            while(cur >= 10)
            {
                int num = cur % 10;
                if(num != 0 && num % 3 == 0) value++;
                cur /= 10;
            }
            if(cur != 0 && cur % 3 == 0) value++;
        }
        
        sw.Write(value);
    }
}