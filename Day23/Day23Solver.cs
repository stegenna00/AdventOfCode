namespace AdventOfCode.Day23;

public class Day23Tests
{
    private readonly ITestOutputHelper _output;
    public Day23Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day23Solver().ExecuteExample1("7");
        
    [Fact] public void Step2WithExample() => new Day23Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day23Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day23Solver().ExecutePuzzle2());
}

public class Day23Solver : SolverBase
{
    // List<??> _data;

    protected override void Parse(List<string> data)
    {
        // _data = new();
    }

    protected override object Solve1()
    {
        throw new Exception("Solver error");
    }

    protected override object Solve2()
    {
        throw new Exception("Solver error");
    }
}
