public class Solution
{
    public bool solution(int x)
    {
        int number = x;
        int value = 0; // x의 자릿수의 합

        while (number > 0)
        {
            value += number % 10;
            number /= 10;
        }

        // x가 x의 자릿수 합으로 나누어 떨어지면 true
        return x % value == 0;
    }
}