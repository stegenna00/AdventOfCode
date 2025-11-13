namespace AdventOfCode.Day02;

public class Day02Tests
{
    private readonly ITestOutputHelper _output;
    public Day02Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day02Solver().ExecuteExample1("2");
        
    [Fact] public void Step2WithExample() => new Day02Solver().ExecuteExample2("4");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day02Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day02Solver().ExecutePuzzle2());
}

public class Day02Solver : SolverBase
    {
        private List<string> _data;

        protected override void Parse(List<string> data)
        {
            _data = data;
        }

        protected override object Solve1()
        {
            var safeCount = 0;

            foreach (var report in _data)
            {
                var levels = report.Split(' ').Select(int.Parse).ToArray();
                bool isIncreasing = levels.SequenceEqual(levels.OrderBy(x => x));
                bool isDecreasing = levels.SequenceEqual(levels.OrderByDescending(x => x));

                if (!isIncreasing && !isDecreasing) continue; // Not monotonic

                bool isValid = true;

                for (int i = 0; i < levels.Length - 1; i++)
                {
                    var diff = Math.Abs(levels[i] - levels[i + 1]);
                    if (diff < 1 || diff > 3)
                    {
                        isValid = false; // Out of the acceptable range
                        break;
                    }
                }

                if (isValid)
                {
                    safeCount++;
                }
            }

            return safeCount;
        }

        protected override object Solve2()
        {
            var safeCount = 0;

            foreach (var report in _data)
            {
                var levels = report.Split(' ').Select(int.Parse).ToArray();

                // First, check if the report is already safe
                if (IsSafe(levels))
                {
                    safeCount++;
                    continue;
                }

                // Now check if removing one level makes it safe
                for (int i = 0; i < levels.Length; i++)
                {
                    var modifiedLevels = levels.Where((_, index) => index != i).ToArray();
                    if (IsSafe(modifiedLevels))
                    {
                        safeCount++;
                        break; // No need to check other removals; one is enough
                    }
                }
            }

            return safeCount;
        }

        private bool IsSafe(int[] levels)
        {
            bool isIncreasing = levels.SequenceEqual(levels.OrderBy(x => x));
            bool isDecreasing = levels.SequenceEqual(levels.OrderByDescending(x => x));

            if (!isIncreasing && !isDecreasing) return false; // Not monotonic

            for (int i = 0; i < levels.Length - 1; i++)
            {
                var diff = Math.Abs(levels[i] - levels[i + 1]);
                if (diff < 1 || diff > 3)
                {
                    return false; // Out of the acceptable range
                }
            }

            return true; // The levels are safe
        }
    }
