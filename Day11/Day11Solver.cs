namespace AdventOfCode.Day11;

public class Day11Tests
{
    private readonly ITestOutputHelper _output;
    public Day11Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day11Solver().ExecuteExample1("55312");
        
    [Fact] public void Step2WithExample() => new Day11Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day11Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day11Solver().ExecutePuzzle2());
}

public class Day11Solver : SolverBase
{
    string _data;

    protected override void Parse(List<string> data)
    {
        _data = data[0];
    }

    protected override object Solve1()
    {
        var newString=_data.Split(' ');
        var stringNumber=newString.ToList();

        for(int i=0; i<25;i++)
        {
            var list = new List<string>();
            foreach(var number in stringNumber)
            {
                CompleteRules(number,list);
            }
            stringNumber=list;
        }
        return stringNumber.Count.ToString();
    
    void CompleteRules(string number,List<string> list)
    {
        if(number=="0")
            list.Add("1");
        else if(number.Length%2==0)
        {
            var first = number.Substring(0,number.Length/2);
            var second = number.Substring(number.Length/2).TrimStart('0');

            if (second=="")
            {
                second="0";
            } 

            list.Add(first);
            list.Add(second);
            
        }
        else
        {
            var n=long.Parse(number);
            var mult= n*2024;
            list.Add(mult.ToString());
        }
    }
    }

    
    
    protected override object Solve2()
    {
        var newString=_data.Split(' ');
        var stringNumber=newString.ToList();

        for(int i=0; i<75;i++)
        {
            var list = new List<string>();
            foreach(var number in stringNumber)
            {
                CompleteRules(number,list);
            }
            stringNumber=list;
        }
        return stringNumber.Count.ToString();
    }

    void CompleteRules(string number,List<string> list)
    {
        if(number=="0")
            list.Add("1");
        else if(number.Length%2==0)
        {
            var first = number.Substring(0,number.Length/2);
            var second = number.Substring(number.Length/2).TrimStart('0');

            if (second=="")
            {
                second="0";
            } 

            list.Add(first);
            list.Add(second);
            
        }
        else
        {
            var n=long.Parse(number);
            var mult= n*2024;
            list.Add(mult.ToString());
        }
    }
}
