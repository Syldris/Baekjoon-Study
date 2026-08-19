using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    public int solution(int[] a)
    {
        int answer = 0;

        // O(N)으로 정보처리뒤에 인덱스 리스트로 스타수열 매칭

        // [값] = 인덱스 리스트.
        List<int>[] arr = new List<int>[a.Length];

        for (int i = 0; i < a.Length; i++)
            arr[i]= new List<int>();

        for (int i = 0; i < a.Length; i++)
        {
            int value = a[i];

            //인덱스 등록
            arr[value].Add(i);
        }

        // 총 갯수가 높은거부터 처리하자.
        Array.Sort(arr, (a, b) => b.Count.CompareTo(a.Count));

        for (int i = 0; i < a.Length; i++)
        {
            List<int> index = arr[i];

            int value = index.Count; // 값의 총 갯수

            if (answer >= value) break; // 갯수가 이미 정답 이하면 더이상 정답 갱신X 갯수순 정렬이기에 뒤에있는것도 전부 정답이하.

            int pair = 0;

            int curIndex = -1; // 매칭 진행 뒤 인덱스.

            bool rightMatch = false; // 오른쪽과 매칭중 인지 여부


            foreach (var item in index)
            {
                if (rightMatch && item > curIndex + 1) // 오른쪽 매칭중이고 중간에 수 하나 매칭 가능상태면. (2,1,2) 등.
                {
                    pair++;
                    curIndex++; // 이전수에서 오른쪽과 매칭했으니 한칸 옮김.
                }

                if (rightMatch) rightMatch = false; // 성공여부 관계없이 오른쪽과 매칭 종료.

                if (item > curIndex + 1) // 현재 기준 왼쪽이랑 매칭가능.
                {
                    pair++;              // 왼쪽에 있는 인덱스와 현재 인덱스 매칭.
                    curIndex = item;
                }
                else // 오른쪽이랑 매칭해야함.
                {
                    curIndex = item;
                    rightMatch = true; // 오른쪽과 매칭해야함.
                }
            }

            if (rightMatch && curIndex < a.Length - 1) // 오른쪽 매칭으로 끝났고 오른쪽에 수가 남아있으면 매칭.
                pair++;

            answer = Max(answer, pair);
        }

        return answer * 2; // 매칭 쌍이니 길이 = 쌍 * 2
    }
}