using System;
public class Solution
{
    public string solution(string s)
    {
        string answer;

        int min = int.MaxValue;
        int max = int.MinValue;

        int[] arr = Array.ConvertAll(s.Split(' '), int.Parse);

        foreach (var item in arr)
        {
            min = Math.Min(min, item);
            max = Math.Max(max, item);
        }

        answer = $"{min} {max}";

        return answer;
    }
}