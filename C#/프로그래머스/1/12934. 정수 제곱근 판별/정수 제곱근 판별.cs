public class Solution
{
    public long solution(long n)
    {
        long start = 1;
        long end = int.MaxValue;

        while (start < end)
        {
            long mid = (start + end) / 2;
            long target = mid * mid;

            if (target == n)
                return (mid + 1) * (mid + 1);

            if (target < n)
                start = mid + 1;
            else
                end = mid;
        }

        return -1;
    }
}