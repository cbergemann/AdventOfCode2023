namespace Day10;

[Flags]
public enum PipeType
{
    Ground = 0,
    North = 1,
    East = 2,
    South = 4,
    West = 8,
    Start = 16,
    PartOfLoop = 32,
    NorthSouth = North | South,
    EastWest = East | West,
    NorthEast = North | East,
    NorthWest = North | West,
    SouthWest = South | West,
    SouthEast = South | East,
}
