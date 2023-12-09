using System.Diagnostics;
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

long GreatestCommonDivisor(long a, long b)
{
    while (a != 0 && b != 0)
    {
        if (a > b)
            a %= b;
        else
            b %= a;
    }

    return a | b;
}

long SmallestCommonMultiple(long a, long b)
{
    return a * b / GreatestCommonDivisor(a, b);
}

long StepsToFinish(Node node, IReadOnlyDictionary<string, Node> nodes, Instructions instructions)
{
    var steps = 0L;
    
    while (!node.IsEndNode)
    {
        var instruction = instructions.Next();
        node = instruction == Instruction.Right ? nodes[node.RightBranch] : nodes[node.LeftBranch];
        steps++;
    }

    return steps;
}

void PartTwo()
{
    var lines = File.ReadAllLines("input.txt");
    var instructions = new Instructions(lines[0]);
    var nodes = lines.Skip(2).Select(Node.FromString).ToDictionary(k => k.Name, v => v);

    var currentNodes = nodes.Values.Where(k => k.IsStartNode).ToList();
    
    var steps = StepsToFinish(currentNodes[0], nodes, new Instructions(instructions));
    for (var it = 1; it < currentNodes.Count; it++)
    {
        var stepsNext = StepsToFinish(currentNodes[it], nodes, new Instructions(instructions));
        steps = SmallestCommonMultiple(steps, stepsNext);
    }
    
    Console.WriteLine($"took {steps} steps as a ghost");
}

PartOne();
PartTwo();
