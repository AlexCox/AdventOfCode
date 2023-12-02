namespace AdventOfCode.Solutions;

internal class Day2 : ISolution
{
    public object SolvePartOne(string[] inputLines)
    {
        var sumOfSuccessfulGameNumbers = 0;
        var gameNumber = 1;
        foreach (var line in inputLines)
        {
            var gameDetails = line.Split(": ");
            var hands = gameDetails[1].Split(';');

            var maxObservedCubes = new Dictionary<string, int>();

            foreach (var hand in hands)
            {
                var cubes = hand.Split(",");
                foreach (var cube in cubes)
                {
                    var cubeDetails = cube.Trim().Split(' ');
                    var cubeCount = int.Parse(cubeDetails[0]);
                    var cubeColour = cubeDetails[1].Trim();

                    if (maxObservedCubes.TryGetValue(cubeColour, out var existingCount) && existingCount >= cubeCount)
                        continue;

                    maxObservedCubes[cubeColour] = cubeCount;
                }
            }

            gameNumber++;

            if (maxObservedCubes.TryGetValue("red", out var redCount) && redCount > 12) continue;
            if (maxObservedCubes.TryGetValue("green", out var greenCount) && greenCount > 13) continue;
            if (maxObservedCubes.TryGetValue("blue", out var blueCount) && blueCount > 14) continue;

            sumOfSuccessfulGameNumbers += gameNumber - 1;
        }
        return sumOfSuccessfulGameNumbers;
    }

    public object SolvePartTwo(string[] inputLines)
    {
        var sumOfPowers = 0;
        foreach (var line in inputLines)
        {
            var gameDetails = line.Split(": ");
            var hands = gameDetails[1].Split(';');

            var maxObservedCubes = new Dictionary<string, int>();

            foreach (var hand in hands)
            {
                var cubes = hand.Split(",");
                foreach (var cube in cubes)
                {
                    var cubeDetails = cube.Trim().Split(' ');
                    var cubeCount = int.Parse(cubeDetails[0]);
                    var cubeColour = cubeDetails[1].Trim();

                    if (maxObservedCubes.TryGetValue(cubeColour, out var existingCount) && existingCount >= cubeCount)
                        continue;

                    maxObservedCubes[cubeColour] = cubeCount;
                }
            }
            sumOfPowers += maxObservedCubes.Values.Aggregate((x, y) => x * y);
        }
        return sumOfPowers;
    }
}