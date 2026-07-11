using System;

public class Solution
{
    public long solution(int[] weights)
    {
        long answer = 0;

        int[] values = new int[1001]; // 무게는 100~1000 이니 이거로 [무게] = 인원 으로 체크.

        for (int i = 0; i < weights.Length; i++)
        {
            values[weights[i]]++;
        }

        for (int weight = 100; weight <= 1000; weight++)
        {
            long value = values[weight];

            if (value == 0) continue;

            // 짝의 갯수 세기 4개 일때
            // (1) [1,1,1]  3개 
            //  1 (1) [1,1] 2개
            //  1 1 (1) [1] 1개
            // 1 ~ value-1 범위 까지 더함.

            // 1 2 3 식으로 연속으로 더하는건 
            // 3 2 1 
            // 4 4 4 이렇게 더해지고 /2로 나눠서 생각해보면 
            // 1~x까지의 합은 (x * x + 1) / 2 개 이다.

            answer += (value - 1) * value / 2; 

            for (int i = 2; i <= 3; i++) // 나의 위치.
            {
                for (int j = i + 1; j <= 4; j++) // 상대의 위치.
                {
                    if (weight * i % j != 0) continue; // 나누어 떨어지지않는 수는 계산 X.

                    // 안하면 100 2 3 일때 200을 3으로 나눌수없는데 66 무게가 더해질수 있음.

                    int pos = weight * i / j;
                    if (pos <= 1000)
                        answer += value * values[pos];
                }
            }
        }

        return answer;
    }
}