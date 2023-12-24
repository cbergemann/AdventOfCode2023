using Day13;

void PartOne()
{
    var reader = File.OpenText("sample.txt");

    var sum = 0L;
    
    while (true)
    {
        var pattern = Pattern.FromReader(reader);
        if (pattern == null)
        {
            break;
        }

        var hsym = pattern.HorizontalSymmetry();
        if (hsym.HasValue)
        {
            sum += hsym.Value + 1;
            continue;
        }

        var vsym = pattern.VerticalSymmetry();
        if (vsym.HasValue)
        {
            sum += 100 * (vsym.Value + 1);
        }
    }

    Console.WriteLine($"total sum: {sum}");
}

void PartTwo()
{
    var reader = File.OpenText("sample.txt");

    var sum = 0L;
    
    while (true)
    {
        var pattern = Pattern.FromReader(reader);
        if (pattern == null)
        {
            break;
        }

        var hsym = pattern.HorizontalSymmetry(1);
        if (hsym.HasValue)
        {
            sum += hsym.Value + 1;
            continue;
        }

        var vsym = pattern.VerticalSymmetry(1);
        if (vsym.HasValue)
        {
            sum += 100 * (vsym.Value + 1);
        }
    }

    Console.WriteLine($"total sum with smudges: {sum}");
}

PartOne();
PartTwo();
