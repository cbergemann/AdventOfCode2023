namespace Day8;

public readonly struct Node(string name, string leftBranch, string rightBranch)
{
    public static Node FromString(string nodeDescription)
    {
        var split1 = nodeDescription.Split(" = (");
        var name = split1[0];
        var split2 = split1[1].TrimEnd(')').Split(", ");
        var leftBranch = split2[0];
        var rightBranch = split2[1];

        return new Node(name, leftBranch, rightBranch);
    }

    public string Name { get; } = name;

    public string LeftBranch { get; } = leftBranch;

    public string RightBranch { get; } = rightBranch;
}