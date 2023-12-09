namespace Day6;

public class Race
{
    private readonly int _duration;
    private readonly long _record;

    public Race(int duration, long record)
    {
        _duration = duration;
        _record = record;
    }

    public int NumberSolutions()
    {
        var solutions = 0;
        for (var it = 0; it < _duration; it++)
        {
            var timeLeft = (long)(_duration - it);
            var distance = timeLeft * it;

            if (distance > _record)
            {
                solutions++;
            }
            else if (solutions > 0)
            {
                break;
            }
        }

        return solutions;
    }
}