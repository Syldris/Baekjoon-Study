using System;
public class Solution
{
    public long solution(int n, int[] works)
    {
        long answer = 0;

        // 피로도는 일들의 작업량 제곱이니까 각 일의 작업량을 균등하게 감소시킬때 최적이다.

        const int SIZE = 50000;

        int[] count = new int[SIZE + 1]; // [작업량] = 갯수
        for (int i = 0; i < works.Length; i++)
        {
            count[works[i]]++;
        }

        for (int i = SIZE; i > 0; i--) // 5만부터 시작해서 높은작업량 일부터 1씩 처리함.
        {
            if (n >= count[i]) // 남은시간 충분.
            {
                n -= count[i]; // i작업량 가진 일들을 1씩처리
                count[i - 1] += count[i]; // 일들은 작업량이 1씩 감소함
                count[i] = 0;
            }
            else
            {
                count[i] -= n; // 남은시간만큼 처리.
                count[i - 1] += n;
                break;
            }
        }

        for (int i = 1; i <= SIZE; i++)
        {
            long value = (long)count[i] * i * i; // i작업량의 제곱 * 갯수
            answer += value;
        }

        return answer;
    }
}