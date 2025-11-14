namespace AdventOfCode.Day07;

public class Day07Tests
{
    private readonly ITestOutputHelper _output;
    public Day07Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day07Solver().ExecuteExample1("3749");
        
    [Fact] public void Step2WithExample() => new Day07Solver().ExecuteExample2("11387");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day07Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day07Solver().ExecutePuzzle2());
}

public class Day07Solver : SolverBase
{
    List<string> _data;

    protected override void Parse(List<string> data)
    {
        _data=data;
    }

    protected override object Solve1()
    {
        long result=0;
        foreach (var levels in _data)
        {
            var parts=levels.Split(": ");
            long target = long.Parse(parts[0]);
            long[] numbers = parts[1].Split(' ').Select(long.Parse).ToArray();

            if(IsSolved(target, numbers))
                result += target;
        }
        return result;
        
        bool IsSolved(long target, long[] numbers)
        {
            int combinations=(int)Math.Pow(2,numbers.Length-1);

            for (int i = 0; i < combinations; i++)
            {
                long res=numbers[0];
                int currentIndex = i;
                for(int j=0; j < numbers.Length-1; j++)
                {
                    if(currentIndex%2 == 1)
                        res *= numbers[j+1];
                    else
                        res += numbers[j+1];

                    currentIndex/=2;
                }
                if(res == target)
                    return true;
            }
            return false;
        }
    }

    protected override object Solve2()
    {
        long result=0;
        foreach (var levels in _data)
        {
            var parts=levels.Split(": ");
            long target = long.Parse(parts[0]);
            long[] numbers = parts[1].Split(' ').Select(long.Parse).ToArray();

            if(IsSolved(target, numbers))
                result += target;
        }
        return result;
        
        bool IsSolved(long target, long[] numbers)
        {
            int combinations=(int)Math.Pow(3,numbers.Length-1);

            for (int i = 0; i < combinations; i++)
            {
                string res=numbers[0].ToString();
                int currentIndex = i;
                for(int j=0; j < numbers.Length-1; j++)
                {
                    if(currentIndex%3 == 0)
                        res = (long.Parse(res) + numbers[j + 1]).ToString();
                    else if(currentIndex%3 == 1)
                        res = (long.Parse(res) * numbers[j + 1]).ToString();
                    else if(currentIndex%3 == 2)
                        res += numbers[j+1].ToString();

                    currentIndex/=3;
                }
                if(long.Parse(res) == target)
                    return true;
            }
            return false;
        }
    }
}
