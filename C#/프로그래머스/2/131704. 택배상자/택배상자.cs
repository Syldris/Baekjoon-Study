using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] order)
    {
        int answer = 0;

        Stack<int> stack = new Stack<int>();

        int number = 1; // 지금까지 받은 박스 번호

        for (int i = 0; i < order.Length; i++)
        {
            while (number < order[i]) // 아직 더받아야하니까 보조컨테이너에 넣기.
            {
                stack.Push(number++);
            }

            if (number == order[i]) // 같으면 집어넣고 다음 박스 받기.
            {
                answer++;
                number++;
            }
            else if (stack.TryPop(out int curOrder) && curOrder == order[i]) // 이전에 넣은 박스 확인
            {
                answer++;
            }
            else
                break;
        }

        return answer;
    }
}