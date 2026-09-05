using System;
using static System.Math;
public class Solution
{
    public long solution(int cap, int n, int[] deliveries, int[] pickups)
    {
        long answer = 0;

        // (배달, 수거)각각 멀리있는 상자부터 보자. (cap = 4 일때 1 2 4) 인경우 1 2 만 처리하는게 최적인데, 1 2 1 이렇게 이동을 1번 더한다.
        // 앞에서 부터 보면 3개만 챙겨가야하는지, 4개를 챙겨야 하는지 체크불가.
        // 뒤에서부터 처리시 항상 Max로 가져가더라도, 4처리후 1 2 남은거보고 최적으로 처리가능하다. 
        // ex) cap = 5 일경우 (1,2,4) => (1,1,0) 으로 2번집에 1개 3번집에 4개 준 꼴로 정확히 처리가능.

        // 수거(4) > 배달(2)로 수거 물품이 뒤에있을때.
        // 2번 배달하면서 가서 4번꺼 수거함. 
        // 픽업(2) <= 배달(4) 인경우 4번 배달하고 돌아오는길에 2번 수거.
        // 둘다 배달후 픽업하는게 같으니 Cap개 만큼 배달후 수거가능. 배달/수거 중 먼 위치까지 왕복으로 한번 이동하게 된다.


        // 마지막 위치 배달. 수거 위치
        int deliverieIndex = 0;
        int pickupIndex = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            if (deliverieIndex == 0 && deliveries[i] > 0)
                deliverieIndex = i;

            if (pickupIndex == 0 && pickups[i] > 0)
                pickupIndex = i;

            if (deliverieIndex != 0 && pickupIndex != 0)
                break;
        }

        // 배달 / 수거 끝냈는지 여부
        bool deliverieClear = false;
        bool pickupClear = false;

        // 둘다 아무것도 없을떄 넘어가게끔 예외처리.
        if(deliverieIndex == 0 && deliveries[0] == 0)
            deliverieClear = true;
        if(pickupIndex == 0 && pickups[0] == 0)
            pickupClear = true;

        while (!deliverieClear || !pickupClear)
        {
            answer += (Max(deliverieIndex, pickupIndex) + 1) * 2; // 둘 중 먼 거리까지 왕복으로 이동하게 되어있음.

            // 각각 최대 cap개씩 처리가능.

            int deliverieCap = cap;
            int pickupCap = cap;

            for (int i = deliverieIndex; i >= 0; i--) // 이전 마지막 위치부터, 
            {
                deliverieIndex = i; // 마지막 위치 기억.

                if (deliverieCap >= deliveries[i]) // 더 배달 가능.
                {
                    deliverieCap -= deliveries[i];
                    if (i == 0) deliverieClear = true; // 0번집 끝내면 끝.
                }
                else // 남은거까지만 배달가능.
                {
                    deliveries[i] -= deliverieCap;
                    break;
                }
            }

            for (int i = pickupIndex; i >= 0; i--)
            {
                pickupIndex = i;

                if (pickupCap >= pickups[i])
                {
                    pickupCap -= pickups[i];
                    if (i == 0) pickupClear = true;
                }
                else
                {
                    pickups[i] -= pickupCap;
                    break;
                }
            }
        }


        return answer;
    }
}