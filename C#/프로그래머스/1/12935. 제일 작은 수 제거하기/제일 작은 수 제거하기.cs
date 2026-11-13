using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] arr)
    {
        if (arr.Length == 1)
            return new int[1] { -1 };

        int minValue = arr[0];
        int removeIndex = 0;
        List<int> list = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            list.Add(arr[i]);
            if (arr[i] < minValue)
            {
                minValue = Math.Min(arr[i], minValue);
                removeIndex = i;
            }
        }

        list.RemoveAt(removeIndex);

        return list.ToArray();
    }
}