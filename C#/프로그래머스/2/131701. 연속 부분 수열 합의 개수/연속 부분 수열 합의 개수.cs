using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] elements)
    {
        HashSet<int> hash = new HashSet<int>();

        int n = elements.Length;

        for (int i = 0; i < n; i++) // 시작 위치
        {
            int value = 0;
            for (int len = 0; len < n; len++) // 자기 뒤로 붙일 연속 부분 수열 길이
            {
                int index = (i + len) % n;
                value += elements[index];
                hash.Add(value);
            }
        }

        return hash.Count;
    }
}