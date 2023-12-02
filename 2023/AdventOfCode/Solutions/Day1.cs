namespace AdventOfCode.Solutions;

internal class Day1 : ISolution
{
    public object SolvePartOne(string[] inputLines)
    {
        var answer = inputLines
            .Select(line =>
            {
                var numbers = line.Where(char.IsNumber).Select(c => c - '0').ToList();
                return 10 * numbers.First() + numbers.Last();
            })
            .Sum();
        return answer;
    }

    public object SolvePartTwo(string[] inputLines)
    {
        var wordsToNumbers = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9
        };

        var answer = inputLines
            .Select(line =>
            {
                var rankedNumbers = new HashSet<(int Position, int Number)>();
                var buffer = string.Empty;
                var i = 0;
                foreach (var c in line)
                {
                    buffer += c;
                    if (char.IsNumber(c))
                    {
                        rankedNumbers.Add((i++, c - '0'));
                        buffer = string.Empty;
                        continue;
                    }

                    foreach (var (word, number) in wordsToNumbers)
                    {
                        var index = buffer.IndexOf(word, StringComparison.Ordinal);
                        if (index == -1) continue;
                        rankedNumbers.Add((i - word.Length + 1, number));
                        // Truncate the buffer
                        buffer = buffer[^1..];
                    }
                    i++;
                }

                return rankedNumbers.MinBy(x => x.Position).Number * 10
                       + rankedNumbers.MaxBy(x => x.Position).Number;
            })
            .Sum();
        return answer;
    }
}