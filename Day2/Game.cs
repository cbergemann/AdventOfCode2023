class Game
{
    public static Game FromString(string config)
    {
        var green = 0;
        var blue = 0;
        var red = 0;

        var cubeDraws = config.Split(',');
        foreach (var cubeDraw in cubeDraws)
        {
            var split = cubeDraw.Trim().Split(' ');
            var count = int.Parse(split[0]);
            var color = split[1];

            switch (color)
            {
                case "green":
                    green += count;
                    break;
                case "blue":
                    blue += count;
                    break;
                case "red":
                    red += count;
                    break;
                default:
                    throw new Exception();
            }
        }

        return new Game(green, blue, red);
    }

    public Game(int green, int blue, int red)
    {
        Green = green;
        Blue = blue;
        Red = red;
    }

    public int Green { get; private set; }

    public int Blue { get; private set; }

    public int Red { get; private set; }

    public bool IsPossible(Game other) => !(other.Green > Green || other.Blue > Blue || other.Red > Red);

    public void Merge(Game other)
    {
        Green = Green < other.Green ? other.Green : Green;
        Blue = Blue < other.Blue ? other.Blue : Blue;
        Red = Red < other.Red ? other.Red : Red;
    }

    public long Power => Green * Blue * Red;
}