namespace AdventOfCode.Day22;

public class Day22Tests
{
    private readonly ITestOutputHelper _output;
    public Day22Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day22Solver().ExecuteExample1("37327623");
        
    [Fact] public void Step2WithExample() => new Day22Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day22Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day22Solver().ExecutePuzzle2());
}

public class Day22Solver : SolverBase
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
