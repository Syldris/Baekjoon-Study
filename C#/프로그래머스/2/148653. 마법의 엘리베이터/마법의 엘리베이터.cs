using System;
public class Solution
{
    public int solution(int storey)
    {
        int answer = 0;
        while (storey > 0)
        {
            int mod = storey % 10;

            storey /= 10;

            if (mod == 5) // 5일땐 빼거나 더하는 횟수가 같고 더하면 다음 자릿수가 +1된다. 
            {
                // 다음 자릿수가 5이상이라면 더해줘서 1번 덜 더하게 이득 되도록 해줄수 있다.

                // 55일때 60 (5번) 100(4번) 0 (1번) 10번.
                // 첫자리여도 5일때 덧셈받으면 6으로, +4 후 그다음 자릿수에서 -1 하는걸로 같다.

                if (storey % 10 >= 5) // 다음 자릿수 5초과일때 더하기 시행.
                {
                    storey++;
                }

                answer += 5; // 더하든 빼든 +5번 이동
            }
            else if (mod < 5) // 5미만이면 항상 빼는게 이득.
            {
                answer += mod;
            }
            else
            {
                answer += 10 - mod; // 10이 되게끔 더해주고
                storey++; // 다음자릿수에 +1
            }
        }

        return answer;
    }
}