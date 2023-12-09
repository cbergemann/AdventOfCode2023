namespace Day8;

public class Instructions
{
    private readonly List<Instruction> _instructions;
    private int _positionPointer = 0;
    
    public Instructions(string description)
    {
        _instructions = new List<Instruction>();
        foreach (var step in description)
        {
            _instructions.Add(step switch
            {
                'R' => Instruction.Right,
                'L' => Instruction.Left,
                _ => throw new Exception(),
            });
        }
    }

    public Instructions(Instructions instructions)
    {
        _instructions = instructions._instructions;
        _positionPointer = instructions._positionPointer;
    }

    public Instruction Next()
    {
        var instruction = _instructions[_positionPointer++];
        if (_positionPointer >= _instructions.Count)
        {
            _positionPointer = 0;
        }

        return instruction;
    }
}