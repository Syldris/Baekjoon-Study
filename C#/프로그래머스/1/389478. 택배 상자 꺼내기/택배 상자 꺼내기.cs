using System;

public class Solution
{
    public int solution(int n, int w, int num)
    {
        int answer = 0;

        int[] arr = new int[w];
        bool add = true;
        int index = 0;

        (int index, int value) box = (0, 0);

        for (int i = 1; i <= n; i++)
        {
            if (i == num) // 선택한 상자 인덱스랑 자기 자신밑 상자갯수 기억.
            {
                box = (index, arr[index]);
            }

            arr[index]++;

            if (i % w == 0) add = !add;
            else if (add) index++;
            else index--;
        }

        return arr[box.index] - box.value;
    }
}