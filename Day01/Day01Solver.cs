namespace AdventOfCode.Day01;

public class Day01Tests
{
    private readonly ITestOutputHelper _output;
    public Day01Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day01Solver().ExecuteExample1("11");
        
    [Fact] public void Step2WithExample() => new Day01Solver().ExecuteExample2("31");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day01Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day01Solver().ExecutePuzzle2());
}

public class Day01Solver : SolverBase
{
    List<(int, int)> _data = new();
    protected override void Parse(List<string> data)
    {
        foreach (var line in data)
        {
            var parts = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            _data.Add((int.Parse(parts[0]), int.Parse(parts[1])));
        }

        var first = _data.Select(x => x.Item1).OrderBy(x => x).ToList();
        var second = _data.Select(x => x.Item2).OrderBy(x => x).ToList();
        _data = first.Zip(second, (f, s) => (f, s)).ToList();
    }

    protected override object Solve1()
    {
        int sum = 0;
        foreach (var (first, second) in _data)
        {
            sum += Math.Abs(first - second);
        }
        return sum;
    }

    protected override object Solve2()
    {
        int sum = 0;
        int counter = 0;
        for(int i = 0; i < _data.Count; i++)
        {
            for (int j = 0; j < _data.Count; j++)
            {
                if (_data[i].Item1 == _data[j].Item2)
                {
                    counter++;
                }
            }
            sum += _data[i].Item1 * counter;
            counter = 0;
        }
        return sum;
    }
}
