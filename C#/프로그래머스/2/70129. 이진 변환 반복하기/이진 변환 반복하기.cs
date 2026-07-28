using System;

public class Solution
{
    public int[] solution(string s)
    {
        int conversionNumber = 0; // 이진 변환 횟수
        int removedZero = 0; // 0 제거 수 

        int zero = 0;
        int one = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
                zero++;
            else
                one++;
        }

        if (zero == 0 && one == 1) // 시작부터 1인 경우.
            return new int[2] { 0, 0 };

        int len = one;
        removedZero += zero;
        conversionNumber++;

        zero = 0;
        one = 0;


        while (len != 1)
        {
            int size = 0;
            for (int i = 0; i < 18; i++)
            {
                if (((len >> i) & 1) == 1)
                    size = i;
            }

            for (int i = 0; i <= size; i++)
            {
                if (((len >> i) & 1) == 1)
                    one++;
                else
                    zero++;
            }

            removedZero += zero;
            len = one;
            conversionNumber++;

            zero = 0;
            one = 0;
        }

        return new int[2] { conversionNumber, removedZero };
    }
}