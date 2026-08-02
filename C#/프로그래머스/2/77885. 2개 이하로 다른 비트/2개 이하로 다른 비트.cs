using System;

public class Solution
{
    public long[] solution(long[] numbers)
    {
        int len = numbers.Length;
        long[] answer = new long[len];

        for (int i = 0; i < len; i++)
        {
            long value = numbers[i];
            int size = 0; // 가장 오른쪽비트부터 연속된 1비트의 갯수 세기.

            for (int k = 0; k < 63; k++)
            {
                if (((value >> k) & 1) == 1)
                    size++;
                else
                    break;
            }

            // 위에서 구한 연속된 1비트의 갯수로 몇개만큼 값을 올리면 되는지 바로 알수있다.
            // size = 0, (0, 1) +1
            // size = 1, (01, 10) +1
            // size = 2, (011, 101) +2
            // size = 3, (0111, 1011) +4
            // size = 4, (01111, 10111) +8
            // 위와 같이 2^(size-1)개 만큼 값을 올리면 비트가 1~2개 다른 가장 작은수를 바로 찾을수있다.

            long diff = 1;
            for (int k = 1; k < size; k++)
            {
                diff *= 2;
            }

            answer[i] = value + diff;

        }
        return answer;
    }
}