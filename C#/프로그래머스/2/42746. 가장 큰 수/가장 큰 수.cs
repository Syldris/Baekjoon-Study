using System;
using System.Text;

public class Solution
{
    public string solution(int[] numbers)
    {
        StringBuilder sb = new StringBuilder();

        int n = numbers.Length;
        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = numbers[i].ToString();
        }

        Array.Sort(arr, (a, b) => -((a + b).CompareTo(b + a))); // 내림차순으로 어느순서로 더했을때 더 큰지 비교하면서 정렬하면 된다.

        if (arr[0] == "0") return "0";

        for (int i = 0; i < n; i++)
        {
            sb.Append(arr[i]);
        }
        return sb.ToString();
    }
}