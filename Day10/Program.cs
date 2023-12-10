using Day10;

void Solution()
{
    var lines = File.ReadAllLines("input.txt");

    var network = new PipeNetwork(lines);

    network.Step();
    var steps = 1L;

    while (network.CurrentPosition != network.Start)
    {
        network.Step();
        steps++;
    }
    
    Console.WriteLine($"steps to farthest location: {steps / 2L} ({steps})");
    Console.WriteLine($"area enclosed: {network.CalculateArea()}");
}

Solution();
