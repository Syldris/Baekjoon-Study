using System;

public struct Timer
{
    public int minute { get; private set; }
    private int _second;

    public int time => minute * 100 + _second;

    public int Second
    {
        get => _second;
        set
        {
            if (value >= 60) // 60초 넘으면 분++
            {
                minute++;
                value -= 60;
            }
            else if (value < 0) // 0초미만이면 분-- 후 60초 추가.
            {
                if (minute > 0)
                {
                    minute--;
                    value += 60;
                }
                else // 0분이면 0분0초로 고정.
                    value = 0;
            }

            _second = value;
            return;
        }
    }

    public Timer(int time)
    {
        minute = time / 100;
        _second = time % 100;
    }
}

public class Solution
{
    public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
    {
        int videoLen = Convert(video_len);
        int startTime = Convert(pos);
        int openingStart = Convert(op_start);
        int openingEnd = Convert(op_end);

        Timer time = new Timer(startTime);

        // 오프닝 중이면 스킵.
        if (openingStart <= time.time &&time.time <= openingEnd)
        {
            time = new Timer(openingEnd);
        }

        for (int i = 0; i < commands.Length; i++)
        {
            string command = commands[i];

            if (command == "prev")
            {
                time.Second -= 10;
            }
            else
            {
                time.Second += 10;
            }

            // 오프닝 중이면 스킵.
            if (openingStart <= time.time && time.time <= openingEnd)
            {
                time = new Timer(openingEnd);
            }

            if (time.time > videoLen) // 비디오 끝길이 이상으론 못넘어감.
            {
                time = new Timer(videoLen);
            }
        }

        return $"{time.minute:D2}:{time.Second:D2}";
    }

    int Convert(string text)
    {
        string[] split = text.Split(':');
        int value = int.Parse(split[0]) * 100 + int.Parse(split[1]);
        return value;
    }
}