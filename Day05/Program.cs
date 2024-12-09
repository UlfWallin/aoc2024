var result = 0L;
List<(int,int)> pairs = []; 
List<int[]> updates = [];
List<int> correctOrder = [];

foreach(var line in  File.ReadLines("sample.txt")) {
    // Start with ruels
    var ruleSep = line.IndexOf('|');
    if (ruleSep > 0) {
        var lhs = int.Parse(line[..ruleSep]);
        var rhs = int.Parse(line[(ruleSep + 1)..]);
        pairs.Add((lhs, rhs));
    }

    if (line.Contains(',')) {
        updates.Add(
            line.Split(',').Select(int.Parse).ToArray()
        );
    }
}

foreach (var pair in pairs) {
    var children = pairs
        .Where(p => p.Item1 == pair.Item1)
        .Select(p=> p.Item2)
        .ToArray();
}

foreach(var upd in updates) {

}

Console.WriteLine(result);
