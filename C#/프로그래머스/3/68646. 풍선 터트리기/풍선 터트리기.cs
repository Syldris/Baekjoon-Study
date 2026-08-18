using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] a)
    {
        int answer = 0;

        /* 간단하게 생각해보면 인접한 두 풍선중 번호가 큰풍선만 터트린다고 하면
         * 본인 풍선기준 좌|우 범위에서 각각 제일 작은 번호 풍선만 남을것이며,
         * 남은 3개의 풍선에서 번호가 더작은 풍선을 부술 기회 1번을 써서 처리할수 있으면 가능
         * 반대로 본인기준 좌|우에서 제일 낮은 풍선이 나보다 둘다 낮다면 불가능하다.
         * ex) 5 2 3 7 1 여기서 3과 7은 불가능하다. 왜냐면 좌우에 2와 1이 있어 최후에 2 n 1 형식으로 남는다. 
         * 좌우에 1개씩 작은수가 있어여하니 양끝은 항상 최후까지 남기는게 가능하다.
         */

        /* a.len >= 100만이니 N^2는 안되고 단조스택을 쓰자.
         * 오름차순 단조스택으로 4 5 6 7 넣다가 본인보다 작은수(4) 오면 
         * 7 6 5 순으로 pop 되고 자신보다 작은수가 양옆에 있는게 확정된다. (오름차순+지금 현재 작은 수) 
        */

        bool[] pass = new bool[a.Length];
        Array.Fill(pass, true);

        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < a.Length; i++)
        {
            while (stack.Count > 0 && a[i] < a[stack.Peek()]) // 조건만족시 반복.
            {
                int index = stack.Pop();

                if (stack.Count > 0) // 본인 왼쪽에 더 작은수가 있을때만.
                    pass[index] = false;
            }

            stack.Push(i);
        }

        // 양끝은 항상 성공.
        pass[0] = true;
        pass[a.Length - 1] = true;

        for (int i = 0; i < a.Length; i++)
            if (pass[i]) answer++;

        return answer;
    }
}