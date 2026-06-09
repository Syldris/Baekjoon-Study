using System;
public class Solution
{
    public int solution(int[] topping)
    {
        int answer = 0;

        int[] count1 = new int[10001]; // [숫자] = 갯수 로 체크
        int[] count2 = new int[10001];

        int toppingType1 = 0;
        int toppingType2 = 0;

        for (int i = 0; i < topping.Length; i++)
        {
            Insert(topping[i], count1, ref toppingType1); // 처음에 모든 토핑 1번케이크에 넣음.
        }

        // 마지막 원소까지 넣으면 2번케이크만 토핑가지니 굳이 할필요 X.
        for (int i = 0; i < topping.Length - 1; i++) // 토핑을 1개씩 2번케이크로 옮겨서 잘랐을때 토핑수 비교. 
        {
            Remove(topping[i], count1, ref toppingType1);
            Insert(topping[i], count2, ref toppingType2);

            if(toppingType1 == toppingType2) // 토핑종류만 같으면 공평.
                answer++;
        }

        return answer;
    }

    void Insert(int num, int[] count, ref int toppingType)
    {
        if (count[num] == 0) // 0개 있던 토핑추가시 토핑종류 +1
            toppingType++;

        count[num]++;
    }

    void Remove(int num, int[] count, ref int toppingType)
    {
        count[num]--;

        if (count[num] == 0) // 토핑제거시 0개되면 토핑종류 -1
            toppingType--;
    }
}