using Day8;

void PartOne()
{
    var lines = File.ReadAllLines("input.txt");
    var instructions = new Instructions(lines[0]);
    var nodes = lines.Skip(2).Select(Node.FromString).ToDictionary(k => k.Name, v => v);

    var steps = 0L;
    var currentNode = nodes["AAA"];
    while (currentNode.Name != "ZZZ")
    {
        var instruction = instructions.Next();
        currentNode = instruction switch
        {
            Instruction.Left => nodes[currentNode.LeftBranch],
            Instruction.Right => nodes[currentNode.RightBranch],
            _ => throw new Exception(),
        };

        steps++;
    }

    Console.WriteLine($"took {steps} steps");
}

PartOne();
