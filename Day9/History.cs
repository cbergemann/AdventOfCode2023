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

        var sum = 0L;
        var lastValue = history.LatestValue;
        while (children.TryPop(out var child))
        {
            lastValue = child.LatestValue + lastValue;
            sum += lastValue;
        }

        return lastValue;
    }

    public bool AllZero => _values.All(v => v == 0L);

    public long LatestValue => _values[^1];
}