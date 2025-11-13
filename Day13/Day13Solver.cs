namespace AdventOfCode.Day13;

public class Day13Tests
{
    private readonly ITestOutputHelper _output;
    public Day13Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day13Solver().ExecuteExample1("480");
        
    [Fact] public void Step2WithExample() => new Day13Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day13Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day13Solver().ExecutePuzzle2());
}

public class Day13Solver : SolverBase
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
