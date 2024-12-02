var lines = File.ReadAllLines("input.txt");
var cntSafe = 0;
var cntSafe2 = 0;

foreach (var line in lines)
{
    var levels = line.Split(' ').Select(s => int.Parse(s)).ToArray();
    if (IsValid(levels))
    {
        cntSafe++;
    }
    else
    {
        // Part two
        for (var i = 0; i < levels.Length; i++)
        {
            var valid = IsValid(levels.Where((e, j) => j != i).ToArray());
            if (valid)
            {
                cntSafe2++;
                break;
            }
        }
    }
}

Console.WriteLine("Part One: {0}", cntSafe);
Console.WriteLine("Part Two: {0}", cntSafe + cntSafe2);

static bool IsValid(int[] levels)
{
    var diffs = levels.Zip(levels[1..], (lhs, rhs) => rhs - lhs).ToArray();

    var outliers = diffs.Any(d => Math.Abs(d) > 3);
    var allDecr = diffs.All(d => d <= -1);
    var allIncr = diffs.All(d => d >= 1);

    if (!outliers && (allIncr || allDecr))
    {
        return true;
    }
    return false;
}