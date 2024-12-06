var lines = File.ReadAllLines("input.txt");
var xmasCount = 0L;
var cols = lines[0].Length;

for (var i = 0; i < lines.Length - 2; i++)
{
    for (var j = 0; j < cols - 2; j++)
    {
        var l1 = lines[i + 0].Substring(j, 3);
        var l2 = lines[i + 1].Substring(j, 3);
        var l3 = lines[i + 2].Substring(j, 3);

        var df = $"{l1[0]}{l2[1]}{l3[2]}";
        var db = $"{l3[0]}{l2[1]}{l1[2]}";

        if ((df == "SAM" || df == "MAS") && (db == "SAM" || db == "MAS"))
        {
            xmasCount++;
        }
    }
}

Console.WriteLine("Part Two: {0}", xmasCount);