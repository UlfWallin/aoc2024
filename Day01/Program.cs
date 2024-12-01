var lines = File.ReadAllLines("input.txt");
var left =  lines.Select(l => int.Parse(l[..(l.IndexOf(' '))])).Order();
var right = lines.Select(l => int.Parse(l[(l.LastIndexOf(' '))..])).Order();
var result = left.Zip(right, (a, b) => Math.Abs(a - b)).Sum();

Console.WriteLine("Part One: " + result);

long sum = 0;
foreach (var num in left) {
    sum += num * right.Count(n => num == n);
}

Console.WriteLine("Part Two: " + sum);
