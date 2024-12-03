using System.Text.RegularExpressions;

var memory = File.ReadAllText("input.txt");
Console.WriteLine("Part One: {0}", ProcessMemory(memory));

// Part two - Preprocess
const string OP_DO = "do()";
const string OP_DONT = "don't()";
var posdont = memory.IndexOf(OP_DONT);
while (posdont > 0)
{
    var posdo = memory.IndexOf(OP_DO, posdont + 1);
    memory = memory.Remove(posdont, posdo - posdont);
    posdont = memory.IndexOf(OP_DONT);
}

Console.WriteLine("Part Two: {0}", ProcessMemory(memory));

static long ProcessMemory(string memory)
{
    var result = 0L;
    var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    var ops = regex.Matches(memory);
    foreach (Match op in ops)
    {
        var ar = op.Value[4..^1]; // Skip "mul(" and ")"
        var opResult = ar    
            .Split(',')
            .Select(int.Parse)
            .Aggregate((c, a) => c * a);

        result += opResult;
    }

    return result;
}