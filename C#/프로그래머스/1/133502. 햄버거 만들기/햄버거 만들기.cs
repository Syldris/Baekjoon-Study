using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] ingredient)
    {
        int answer = 0;

        List<int> list = new List<int>();

        for (int i = 0; i < ingredient.Length; i++)
        {
            list.Add(ingredient[i]);

            if (list.Count >= 4)
            {
                if (list[^1] == 1 && list[^2] == 3 && list[^3] == 2 && list[^4] == 1) // 빵 야채 고기 빵 순서일때 햄버거 완성
                {
                    answer++;
                    list.RemoveRange(list.Count - 4, 4); // 뒤쪽 4개 지우기. O(1)
                }
            }
        }

        return answer;
    }
}