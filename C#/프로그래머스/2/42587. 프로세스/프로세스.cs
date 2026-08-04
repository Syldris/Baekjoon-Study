using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] priorities, int location)
    {
        Queue<int> queue = new Queue<int>();

        int[] arr = new int[10]; // [값] = 갯수 저장 배열.
        for (int i = 0; i < priorities.Length; i++)
        {
            int value = priorities[i];
            arr[value]++;
            queue.Enqueue(i);
        }

        int order = 0; // 실행된 순서.

        while (queue.Count > 0)
        {
            int index = queue.Dequeue();

            int value = priorities[index];
            bool pass = true;
            for (int i = value + 1; i < 10; i++)
            {
                if (arr[i] > 0) // 자신보다 큰 우선순위가 남아있으면 다시 삽입.
                {
                    pass = false;
                    queue.Enqueue(index);
                    break;
                }
            }

            if (pass)
            {
                order++;
                arr[value]--;

                if (index == location)
                    return order;
            }
        }

        return 0;
    }
}