using System.Text.RegularExpressions;

var memory = File.ReadAllText("input.txt");
Console.WriteLine("Part One: {0}", ProcessMemory(memory));

// Part two - Preprocess
const string OP_DO = "do()";
const string OP_DONT = "don't()";
var posDont = memory.IndexOf(OP_DONT);
while (posDont > 0)
{
    var posDo = memory.IndexOf(OP_DO, posDont + 1);
    memory = memory.Remove(posDont, posDo - posDont);
    posDont = memory.IndexOf(OP_DONT);
}

Console.WriteLine("Part Two: {0}", ProcessMemory(memory));

static long ProcessMemory(string memory)
{
    var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    var result = 0L;
    var ops = regex.Matches(memory);
    foreach (Match op in ops)
    {
        result += int.Parse(op.Groups[1].Value) * int.Parse(op.Groups[2].Value);
    }

    return result;
}