namespace Day10;

public record Position(int Row, int Col);
    
public class PipeNetwork
{
    private readonly PipeType[,] _layout;
    
    public PipeNetwork(string[] lines)
    {
        _layout = new PipeType[lines.Length, lines[0].Length];
        Start = new Position(-1, -1);
    
        for (var row = 0; row < lines.Length; row++)
        {
            for (var col = 0; col < lines[0].Length; col++)
            {
                _layout[row, col] = lines[row][col] switch
                {
                    '.' => PipeType.Ground,
                    '|' => PipeType.NorthSouth,
                    '-' => PipeType.EastWest,
                    'L' => PipeType.NorthEast,
                    'J' => PipeType.NorthWest,
                    '7' => PipeType.SouthWest,
                    'F' => PipeType.SouthEast,
                    'S' => PipeType.Start,
                    _ => throw new Exception(),
                };

                if (_layout[row, col] == PipeType.Start)
                {
                    Start = new Position(row, col);
                }
            }
        }

        if (Start.Row == -1)
        {
            throw new Exception();
        }

        _layout[Start.Row, Start.Col] = DetermineStartPipe();
        CurrentPosition = Start;
        PreviousPosition = Start;
    }

    public Position Start { get; }

    public Position CurrentPosition { get; private set; }

    private Position PreviousPosition { get; set; }

    public void Step()
    {
        var previousPosition = PreviousPosition;
        PreviousPosition = CurrentPosition;
        
        var currentPipe = this[CurrentPosition];
        var northPosition = CurrentPosition with { Row = CurrentPosition.Row - 1 };
        var eastPosition = CurrentPosition with { Col = CurrentPosition.Col + 1 };
        var southPosition = CurrentPosition with { Row = CurrentPosition.Row + 1 };
        var westPosition = CurrentPosition with { Col = CurrentPosition.Col - 1 };
        
        if ((currentPipe & PipeType.North) != 0 && previousPosition != northPosition)
        {
            CurrentPosition = northPosition;
            return;
        }
        
        if ((currentPipe & PipeType.East) != 0 && previousPosition != eastPosition)
        {
            CurrentPosition = eastPosition;
            return;
        }

        if ((currentPipe & PipeType.South) != 0 && previousPosition != southPosition)
        {
            CurrentPosition = southPosition;
            return;
        }

        if ((currentPipe & PipeType.West) != 0 && previousPosition != westPosition)
        {
            CurrentPosition = westPosition;
            return;
        }

        throw new Exception("stuck");
    }

    private PipeType this[Position position] => this[position.Row, position.Col];

    private PipeType this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= _layout.GetLength(0) || col < 0 || col >= _layout.GetLength(1))
            {
                return PipeType.Ground;
            }

            return _layout[row, col];
        }
    }

    private PipeType DetermineStartPipe()
    {
        var startPipe = PipeType.Ground;
        var northPosition = Start with { Row = Start.Row - 1 };
        var eastPosition = Start with { Col = Start.Col + 1 };
        var southPosition = Start with { Row = Start.Row + 1 };
        var westPosition = Start with { Col = Start.Col - 1 };

        if ((this[westPosition] & PipeType.East) != 0)
        {
            startPipe |= PipeType.West;
        }

        if ((this[northPosition] & PipeType.South) != 0)
        {
            startPipe |= PipeType.North;
        }

        if ((this[southPosition] & PipeType.North) != 0)
        {
            startPipe |= PipeType.South;
        }

        if ((this[eastPosition] & PipeType.West) != 0)
        {
            startPipe |= PipeType.East;
        }

        return startPipe;
    }
}