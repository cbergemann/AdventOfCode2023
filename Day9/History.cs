namespace Day9;

public class History
{
    private readonly long[] _values;

    public History(string line)
    {
        _values = line.Split(' ').Select(long.Parse).ToArray();
    }

    public History(History parent)
    {
        _values = parent._values.Zip(parent._values.Skip(1), (a, b) => b - a).ToArray();
    }

    public long ExtrapolateNextValue()
    {
        var children = new Stack<History>();
        var history = this;

        while (!history.AllZero)
        {
            children.Push(history);
            history = new History(history);
        }

        var lastValue = history.LatestValue;
        while (children.TryPop(out var child))
        {
            lastValue = child.LatestValue + lastValue;
        }

        return lastValue;
    }
    
    public long ExtrapolatePreviousValue()
    {
        var children = new Stack<History>();
        var history = this;

        while (!history.AllZero)
        {
            children.Push(history);
            history = new History(history);
        }

        var firstValue = history.FirstValue;
        while (children.TryPop(out var child))
        {
            firstValue = child.FirstValue - firstValue;
        }

        return firstValue;
    }

    public bool AllZero => _values.All(v => v == 0L);

    public long LatestValue => _values[^1];

    public long FirstValue => _values[0];
}