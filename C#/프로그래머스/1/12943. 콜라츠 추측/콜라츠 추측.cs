public class Solution
{
    public int solution(int num)
    {
        int answer = 0;
        long number = num;

        while (answer <= 500 && number != 1) // 501번까지 수행.
        {
            if (number % 2 == 0)
                number /= 2;
            else
                number = number * 3 + 1;
            answer++;
        }

        return answer <= 500 ? answer : -1; // 500 넘으면 -1로.
    }
}