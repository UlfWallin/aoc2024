using System.Text.RegularExpressions;

var memory = File.ReadAllText("input.txt");

Console.WriteLine("Part One: {0}", Mult(memory));

const string OP_DO = "do()";
const string OP_DONT = "don't()";

// Part two - Preprocess
var posdont = 0;
posdont = memory.IndexOf(OP_DONT);
while (posdont > 0)
{
    if (posdont > 0)
    {
        var posdo = memory.IndexOf(OP_DO, posdont + 1);
        memory = memory.Remove(posdont, posdo - posdont);
    }
    posdont = memory.IndexOf(OP_DONT);
}

Console.WriteLine("Part Two: {0}", Mult(memory));

static long Mult(string memory)
{
    var result = 0L;
    var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    var ops = regex.Matches(memory);
    foreach (Match op in ops)
    {
        var ar = op.Value[4..]; // Skip "mul("
        var nums = ar[..^1] // Skip last ')'
            .Split(',')
            .Select(int.Parse)
            .ToArray();
        result += nums[0] * nums[1];
    }

    return result;
}