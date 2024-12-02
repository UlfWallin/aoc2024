var result = 0L;
var lines = File.ReadAllLines("sample.txt");
var counsSafe = 0;

foreach(var line in lines) {
    var levels = line.Split(' ').Select(s => int.Parse(s)).ToArray();
    var diffs = levels.Zip(levels[1..], (lhs, rhs) => rhs - lhs).ToArray();
    
    var outliers = diffs.Any(d => Math.Abs(d) > 3);
    var allIncr = diffs.All(d => d <= -1);
    var allDecr = diffs.All(d => d >= 1);
        
    if (!outliers && (allIncr || allDecr)) {
        counsSafe++;
    }
    else {
        // Part two
        
    }
}

result = counsSafe;

Console.WriteLine(result);
