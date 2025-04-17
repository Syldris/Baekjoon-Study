using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < t; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            long k = long.Parse(inputs[1]);

            List<long> nums = new List<long>();

            while (k != 0)
            {
                string klen =  k.ToString();
                long firstNum = klen[0] - '0';

                int start = 1;

                while (firstNum > 0)
                {
                    long equalNum = firstNum;

                    for (int j = start; j < klen.Length; j++)
                    {
                        equalNum *= 10;
                        equalNum += firstNum;
                    }

                    if (k >= equalNum)
                    {
                        k -= equalNum;
                        nums.Add(equalNum);
                        break;
                    }
                    if (firstNum > 1)
                        firstNum--;
                    else
                    {
                        start++;
                        firstNum = 9;
                    }
                }
   
            }
            sb.AppendLine(nums.Count.ToString());
            sb.AppendLine(String.Join(" ", nums));
        }
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        sw.WriteLine(sb.ToString());
        sw.Flush();
    }
}
