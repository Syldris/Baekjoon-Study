using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] queue1, int[] queue2)
    {
        int answer = 0;
        int n = queue1.Length;

        Queue<int> Queue1 = new Queue<int>();
        Queue<int> Queue2 = new Queue<int>();

        long value1 = 0;
        long value2 = 0;
        for (int i = 0; i < n; i++)
        {
            value1 += queue1[i];
            value2 += queue2[i];

            Queue1.Enqueue(queue1[i]);
            Queue2.Enqueue(queue2[i]);
        }

        /* Max 교환횟수는 어느정도 일까? 
         * 두 큐의 삽입 삭제를 생각해보면 원형배열로도 나타낼수있다. 
         * 큐 1의 범위를 | 큐1 원소들 | 로 나타내겟다. 큐2는 나머지 부분. 
         * | 1 2 3 4 | 5 6 7 8  n=4 일때 시작상태다.
         * 시작 구간을 l. 끝구간을 r 로 잡으면 l = 0, r = n 으로 시작한다.
         * 두 큐 합이 같을떄 한쪽 큐가 빈 큐일수 없다는 성질을 생각하자.
         * | 1 2 3 4 5 6 7 | 8 로 r은 총 n-1번 이동가능하다.
         * 1 2 3 4 5 6 | 7 | 8 로 l은 위 상태(2n-1개 원소)에서 최대 2n-2번 움직임 가능하다.
         * 고로 총 움직임은 3n-3번이다. l, r 모두 => 로 움직이는 원형배열의 회전으로 생각하면 된다.
            */

        while (value1 != value2 && answer < n * 3 - 3)
        {
            answer++;
            if (value1 > value2)
            {
                int pop = Queue1.Dequeue();
                value1 -= pop;
                Queue2.Enqueue(pop);
                value2 += pop;
            }
            else
            {
                int pop = Queue2.Dequeue();
                value2 -= pop;
                Queue1.Enqueue(pop);
                value1 += pop;
            }
        }

        return value1 == value2 ? answer : -1;
    }
}