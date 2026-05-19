using System;
using System.Text;

public class Solution
{
    public int solution(int n, int k)
    {
        int answer = 0;

        StringBuilder sb = new StringBuilder();

        while (n > 0)
        {
            // 10진수를 생각하면서 계산하자 나머지 계산후 나누기 반복
            // 135 같은 수를 10진수로 나타낼때 10 나머지인 5 3 1 순으로 빠진다
            // 즉 역순으로 저장됨
            sb.Append(n % k);
            n /= k;
        }

        char[] chars = new char[sb.Length];

        for (int i = 0; i < sb.Length; i++)
        {
            // 역순인거 되돌리기
            chars[sb.Length - 1 - i] = sb[i];
        }

        long value = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != '0') // 0이 아닌경우 숫자를 더함
            {
                value *= 10;
                value += chars[i] - '0';
            }
            else // 0인경우 숫자 자르고 소수인지 판별
            {
                if (PrimeCheck(value)) answer++;

                value = 0;
            }
        }

        if (PrimeCheck(value)) answer++; // 남은 수도 체크

        return answer;
    }

    public bool PrimeCheck(long value) // O(SqrtN) 판별.
    {
        if (value == 0 || value == 1) return false;

        int sqrtValue = (int)Math.Sqrt(value) + 1;

        // 약수는 항상 2 3 | 3 2 이런식으로 대칭적으로 나타낼수있는데 sqrtN까지 찾아서 없다면
        // x > sqrtN 및 a < sqrtN일때 x * a 는 a * x 에서 이미 검사했다. 
        // 그러므로 sqrtN까지만 검사 해도 됨.

        for (int i = 2; i < sqrtValue; i++)
        {
            if (value % i == 0)
                return false;
        }

        return true;
    }
}