using System;
using static System.Math;

public class Solution
{
    public int solution(int[] arrayA, int[] arrayB)
    {
        int answer = 0;

        // 조건1. arrA배열을 모두 나눌수 있으며
        // arrB배열을 하나도 나눌수 없는 가장 큰 정수 X 구하기.
        // arrA의 최대공약수를 구하면 된다. 최대공약수로 B가 나눠지면 실패.
        // 최대공약수(12) 대신 다른 약수(2,3,4,6)를 써도 최대공약수로 나눠지니 다른약수로도 나눠짐이 보장됨.

        // 조건2. arrB를 모두 나누고 arrA를 모두 나눌수없는 X 또한 후보.

        int gcd = GCD(arrayA); // arrayA를 모두 나누는 최대공약수.

        for (int i = 0; i < arrayB.Length; i++)
        {
            if (arrayB[i] % gcd == 0) // 최대공약수로 나눠 떨어지면 B를 못나누는 약수가 없음.
            {
                gcd = 0;
                break;
            }
        }

        answer = Max(answer, gcd);

        gcd = GCD(arrayB); 

        for (int i = 0; i < arrayA.Length; i++)
        {
            if (arrayA[i] % gcd == 0) // 최대공약수로 나눠 떨어지면 A를 못나누는 약수가 없음.
            {
                gcd = 0;
                break;
            }
        }

        answer = Max(answer, gcd);

        return answer;
    }

    int GCD(int[] arr)
    {
        int value = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            int a = value;
            int b = arr[i];

            while (b != 0) // a = bq + r 일때, gcd(a,b) == gcd(b,r)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            value = a;
        }
        return value;
    }
}