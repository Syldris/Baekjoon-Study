public class Solution
{
    public int solution(int[] arr)
    {
        int answer = arr[0];

        // 최소공배수는 원소에 대해 x1*x2 / gcd(x1,x2) 성립.
        for (int i = 1; i < arr.Length; i++)
        {
            int temp = answer;

            temp *= arr[i];
            temp /= GCD(answer, arr[i]);

            answer = temp;
        }


        return answer;
    }


    // a,b 일때 a = bq+r 이러면 gcd(a,b) = gcd(b,r)
    // 최대공약수를 d로 둔다면, a와 b는 d로 나뉜다.

    // a = k1*d; b = k2*d;
    // r = d(k2q - k1) 로 r도 d로 나뉜다.
    // 즉 (a,b) 와 (b,r) 공약수 집합이 같다.

    int GCD(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
}