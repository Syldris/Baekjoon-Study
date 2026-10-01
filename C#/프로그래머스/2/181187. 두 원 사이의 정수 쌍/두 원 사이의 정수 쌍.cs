using System;
using static System.Math;
public class Solution
{
    public long solution(int r1, int r2)
    {
        long answer = 0;

        // 원을 1/4토막내서 
        // y = 0 ~ r2 공간에 대해 r1과 r2 x좌표에 몇개들어가는지 세자.

        // 피타고라스 식으로 r^2 = x^2+y^2 이다. 
        // 이항해서 x좌표는 x^2 = r^2-y^2 이다.

        long r1Pow = (long)r1 * r1;
        long r2Pow = (long)r2 * r2;

        for (long y = 0; y <= r2; y++)
        {
            long r1X, r2X; // double => int 형변환 하면서 자동내림처리

            if (y >= r1) r1X = 0;
            else
            {
                r1X = (long)Sqrt(r1Pow - y * y);

                // r1원의 x좌표가 정확히 정수에 위치해있다면, r1위 x좌표도 점으로 포함해야한다. (r1 원 위의 점도 포함)
                // r1^2 - y^2 = x^2 이다. 이값이 정수로 내림한 r1x^2 == x^2 라면,
                // 내림으로 버려진 소수부분이 없으니 x가 정수라고 볼수있다

                if (r1Pow - y * y == r1X * r1X)
                    r1X--; // r1원 위의 점을 포함
            }

            r2X = (long)Sqrt(r2Pow - y * y);

            answer += r2X - r1X;
        }

        return answer * 4; // 전부세고 1/4 원을 4배로 해서 원사이 점갯수 완성.
    }
}