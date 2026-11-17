public class Solution
{
    public long solution(int a, int b)
    {
        long answer = 0;

        if (a > b)
            (a, b) = (b, a);

        long len = (b - a) + 1;

        // 0부터 시작하는 등차1수열.
        // 0 1 2 3
        // 3 2 1 0
        // + + + +
        // 3 3 3 3 = 12 / 2 = 10

        answer = len * (len - 1) / 2;

        answer += len * a; // a
        return answer;
    }
}