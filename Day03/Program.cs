using System.Text.RegularExpressions;

var mem = File.ReadAllText("input.txt");
Console.WriteLine("Part One: {0}", ProcessMemory(mem));

// Part two - Preprocess
const string OP_DO = "do()";
const string OP_DONT = "don't()";
var posDont = mem.IndexOf(OP_DONT);
while (posDont > 0)
{
    var posDo = mem.IndexOf(OP_DO, posDont + 1);
    mem = mem.Remove(posDont, posDo - posDont);
    posDont = mem.IndexOf(OP_DONT);
}

Console.WriteLine("Part Two: {0}", ProcessMemory(mem));

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