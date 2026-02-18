
using System;
using System.IO;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);
        int n = int.Parse(sr.ReadLine());
        string[] arr = sr.ReadLine().Split();

        int zero = 0, one = 0, two = 0, three = 0;

        for(int i = 0; i < n; i++)
        {
            switch(arr[i])
            {
                case "0":
                    zero++; break;
                case "1":
                    one++; break;
                case "2":
                    two++; break;
                case "3":
                    three++; break;
            }
        }

        int value = 0;

        while(three > 0 && zero > 0)
        {
            zero--;
            three--;
            value += 3;
        }

        while(one > 0 && two > 0)
        {
            one--;
            two--;
            value += 3;
        }

        while(zero > 0)
        {
            if(two > 0)
            {
                zero--;
                two--;
                value += 2;
            }
            else if(one > 0)
            {
                zero--;
                one--;
                value++;
            }
            else break;
        }
        
        while(one > 0 && three > 0)
        {
            one--;
            three--;
            value += 2;
        }
        
        while(two > 0 && three > 0)
        {
             two--;
             three--;
             value++;
        }
        
        sw.Write(value);
    }
}