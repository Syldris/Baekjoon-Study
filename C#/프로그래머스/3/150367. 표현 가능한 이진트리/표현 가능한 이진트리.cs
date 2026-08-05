using System;
using System.Text;

public class Solution
{
    public int[] solution(long[] numbers)
    {
        int n = numbers.Length;
        int[] answer = new int[n];

        /*
         * 문제 설명이 좀 꼬여있지만 이해하게끔 요약하자면,
         * 이진트리에 더미노드를 추가해서 포화이진트리로 만들고
         * 빈 더미노드를 0, 차있는 노드를 1로 나타낸다.
         * 
         * 1111111 이렇게 있을때 가운데(4)부터 루트. 4를 기준으로 
         * 왼쪽(2) 오른쪽(6) 이렇게 순서상으로 나타낼수있다.
         * 
         * 원래 받은 십진수를 위와같은 이진수로 변환가능한지 체크하면된다.
         * 만약 자식이 1일때, 부모가 0이라면 모순으로 불가능한 수다.
         */

        for (int i = 0; i < n; i++)
        {
            long value = numbers[i];
            int len = Log2(value) + 1; // 이진수로 나타낼때 길이체크.

            int size = 1;

            while(size <= len) // 포화 이진트리 갯수는 (2^높이) -1개다. 1,3,7,15,31 등의 갯수로 채워서 보정.
            {
                size *= 2;
            }
            size--;

            bool[] tree = new bool[size + 1]; // 포화 이진트리니까 배열로 나타내기 가능.

            for (int k = 0; k < size; k++)
            {
                tree[k + 1] = ((value >> k) & 1) == 1; // 1-index기반.
            }

            int rootIndex = size / 2 + 1;

            bool pass = DFS(rootIndex, rootIndex / 2, tree);

            answer[i] = pass ? 1 : 0;
        }


        return answer;
    }

    int Log2(long number) // 소숫점 버림 
    {
        int value = 0;

        while (number > 1)
        {
            value++;
            number /= 2;
        }

        return value;
    }

    bool DFS(int index, int move, bool[] tree)
    {
        if (move == 0) return true;

        int leftNodeIndex = index + move;
        int rightNodeIndex = index - move;

        bool leftDFS = DFS(leftNodeIndex, move / 2, tree);
        bool rightDFS = DFS(rightNodeIndex, move / 2, tree);

        if (!leftDFS || !rightDFS) // 불가능한게 자식에서 발견되면 부모까지 전파.
            return false;

        // 자기 자신이 더미노드(0)인데 자식이 실제노드(1)이라면 이진트리 => 포화이진트리 과정에서 나올수없는 모순이다.
        if (!tree[index] && (tree[leftNodeIndex] || tree[rightNodeIndex]))
            return false;

        return true;
    }

}