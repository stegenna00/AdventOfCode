namespace AdventOfCode.Day22;

public class Day22Tests
{
    private readonly ITestOutputHelper _output;
    public Day22Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day22Solver().ExecuteExample1("37327623");
        
    [Fact] public void Step2WithExample() => new Day22Solver().ExecuteExample2("24");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day22Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day22Solver().ExecutePuzzle2());
}

public class Day22Solver : SolverBase
{
    List<string> _data;

    protected override void Parse(List<string> data)
    {
        _data = data;
    }

    protected override object Solve1()
    {
        long result=0;
        var numbers= _data.Select(s => long.Parse(s)).ToList();

            for(int i=0; i<numbers.Count;i++)
            {
                long value = numbers[i];
                for(int j=0; j<2000;j++)
                {
                    value=FirstStep(value);
                    value=SecondStep(value);
                    value=ThirdStep(value);
                }
                result+=value;
            }

        return result;

        long FirstStep(long secretNumber)
        {
            var molt=secretNumber*64L;
            var mix=secretNumber^molt;
            var prune=mix%16777216L;
            secretNumber=prune;
            return secretNumber;
        }
        long SecondStep(long secretNumber)
        {
            var div=secretNumber/ 32L;
            var mix=secretNumber^div;
            var prune=mix%16777216L;
            secretNumber=prune;
            return secretNumber;
        }
        long ThirdStep(long secretNumber)
        {
            var molt=secretNumber*2048L;
            var mix=secretNumber^molt;
            var prune=mix%16777216L;
            secretNumber=prune;
            return secretNumber;
        }
    }

    protected override object Solve2()
    { 
        var sequence = new Dictionary<(long,long,long,long), long>();
        var numbers= _data.Select(s => long.Parse(s)).ToList();

            foreach(var number in numbers)
            {
                long value = number;
                var buyer = new List<long> {value % 10};
                
                for(int j=0; j<2000;j++)
                {
                    value=FirstStep(value);
                    value=SecondStep(value);
                    value=ThirdStep(value);
                    buyer.Add(value%10);
                }

                var seen = new HashSet<(long,long,long,long)>();

                for(int i=0; i<buyer.Count - 4;i++)
                {
                    long a=buyer[i];
                    long b=buyer[i+1];
                    long c=buyer[i+2];
                    long d=buyer[i+3];
                    long e=buyer[i+4];
                    var seq = (b - a, c - b, d - c, e - d);
                    if(seen.Contains(seq))
                    {
                        continue;
                    }
                    seen.Add(seq);
                    if(!sequence.ContainsKey(seq))
                        sequence[seq]=0;
                    sequence[seq] += e;
                }
            }
        return sequence.Values.Max();

        long FirstStep(long secretNumber)
        {
            var molt=secretNumber*64L;
            var mix=secretNumber^molt;
            var prune=mix%16777216L;
            secretNumber=prune;
            return secretNumber;
        }
        long SecondStep(long secretNumber)
        {
            var div=secretNumber/ 32L;
            var mix=secretNumber^div;
            var prune=mix%16777216L;
            secretNumber=prune;
            return secretNumber;
        }
        long ThirdStep(long secretNumber)
        {
            var molt=secretNumber*2048L;
            var mix=secretNumber^molt;
            var prune=mix%16777216L;
            secretNumber=prune;
            return secretNumber;
        }
    }
}
