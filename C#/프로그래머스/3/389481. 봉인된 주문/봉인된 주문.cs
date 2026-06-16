using System;
using System.Text;

public class Solution
{
    public string solution(long n, string[] bans)
    {
        int len = bans.Length;
        long[] banOrder = new long[len]; // 몇번째 주문이 밴되는지 기록.

        for (int i = 0; i < len; i++)
        {
            string magic = bans[i]; // 26진법으로 생각하자.

            long order = 0;
            long multiple = 1;
            for (int k = magic.Length - 1; k >= 0; k--)
            {
                order += (magic[k] - 'a' + 1) * multiple; // a~z(1~26) * 진법 배수.  
                multiple *= 26; // 앞자리일때마다 26배.
            }

            banOrder[i] = order;
        }

        Array.Sort(banOrder); // 작은 마법부터 밴해야 큰수를 놓치는 상황이 안펼쳐짐. ex) n = 25 일때 26번밴후 25번밴 같은 상황 X

        for (int i = 0; i < len; i++)
        {
            if (n >= banOrder[i]) // n번째 주문안에 밴할 주문이 포함되어있다면.
            {
                n++; // N+1번째 주문이 n번째 주문이 됨.
            }
        }

        StringBuilder sb = new StringBuilder();

        while (n > 0)
        {
            n--; // 1~26으로 계산하던 진법 0~25로 변환.
            long mod = n % 26;

            sb.Append((char)('a' + mod)); // a~z 0~25

            n /= 26; // 이후 나누면서 또 다음숫자때 -1 반복 순환.
        }

        int textSize = sb.Length;
        char[] chars = new char[textSize];

        for (int i = 0; i < textSize; i++)
            chars[i] = sb[textSize - 1 - i]; // 역순배치.

        return new string(chars);
    }
}