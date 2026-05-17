using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(string[] want, int[] number, string[] discount)
    {
        int answer = 0;

        int n = want.Length;
        int[] items = new int[n];

        // 물건 이름 => 인덱스로 변환
        Dictionary<string, int> dict = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            dict.Add(want[i], i);
        }

        // 물건 10일치 할인 기록하고 시작
        for (int i = 0; i < 10; i++)
        {
            if (dict.ContainsKey(discount[i]))
            {
                items[dict[discount[i]]]++;
            }
        }

        if (check(number, items)) answer++;

        for (int i = 10; i < discount.Length; i++)
        {
            if (dict.ContainsKey(discount[i]))
            {
                items[dict[discount[i]]]++;
            }

            // 10일동안 할인이니 11일차부턴 1일차 제거
            if (dict.ContainsKey(discount[i - 10]))
            {
                items[dict[discount[i - 10]]]--;
            }

            if (check(number, items)) answer++;
        }

        return answer;
    }

    public bool check(int[] number, int[] items)
    {
        int len = number.Length;

        for (int i = 0; i < len; i++)
        {
            if (items[i] < number[i]) // 필요한 물건이 더 많으면 실패.
                return false;
        }

        return true;
    }
}