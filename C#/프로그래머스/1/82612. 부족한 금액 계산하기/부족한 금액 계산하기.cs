using System;

class Solution
{
    public long solution(int price, int money, int count)
    {
        // 등차수열 항길이 * (첫항+마지막항) /2
        // n = 10 등차 예시로 5가 4개. 그리고 /2 하면 딱맞음.
        // 10 20 30 40
        // 40 30 20 10  

        long lastPrice = price * count;

        long cost = count * (price + lastPrice) / 2;

        if (cost > money) return cost - money; // 얼마 모자른지 리턴.
        else return 0; 
    }
}