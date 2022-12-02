using System.Reflection;

var filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
var lines = File.ReadAllLines($@"{filePath!}\1.txt").ToArray();

const int win = 6;
const int draw = 3;

Console.WriteLine(FirstPartAnswer(lines));
Console.WriteLine(SecondPartAnswer(lines));

static int FirstPartAnswer(IEnumerable<string> strings)
{
    var total = 0;

    foreach (var line in strings)
    {
        var opponentSelection = line[0];
        var mySelection = line[2];
        var roundScore = 0;

        switch (mySelection)
        {
            case 'X' when opponentSelection == 'C':
                roundScore += win;
                break;
            case 'X' when opponentSelection == 'A':
                roundScore += draw;
                break;
            case 'Y' when opponentSelection == 'A':
                roundScore += win;
                break;
            case 'Y' when opponentSelection == 'B':
                roundScore += draw;
                break;
            case 'Z' when opponentSelection == 'B':
                roundScore += win;
                break;
            case 'Z' when opponentSelection == 'C':
                roundScore += draw;
                break;
        }

        roundScore += (int)Enum.Parse<MyOptions>(mySelection.ToString());
        total += roundScore;
    }

    return total;
}

static int SecondPartAnswer(IEnumerable<string> strings)
{
    var total = 0;

    foreach (var line in strings)
    {
        var opponentSelection = line[0];
        var roundOutcome = line[2];
        var roundScore = 0;
        char mySelection = char.MinValue;

        switch (roundOutcome)
        {
            case 'X' when opponentSelection == 'A':
                mySelection = 'Z';
                break;
            case 'X' when opponentSelection == 'B':
                mySelection = 'X';
                break;
            case 'X' when opponentSelection == 'C':
                mySelection = 'Y';
                break;
            case 'Y' when opponentSelection == 'A':
                mySelection = 'X';
                roundScore += draw;
                break;
            case 'Y' when opponentSelection == 'B':
                mySelection = 'Y';
                roundScore += draw;
                break;
            case 'Y' when opponentSelection == 'C':
                mySelection = 'Z';
                roundScore += draw;
                break;
            case 'Z' when opponentSelection == 'A':
                mySelection = 'Y';
                roundScore += win;
                break;
            case 'Z' when opponentSelection == 'B':
                mySelection = 'Z';
                roundScore += win;
                break;
            case 'Z' when opponentSelection == 'C':
                mySelection = 'X';
                roundScore += win;
                break;
        }

        roundScore += (int)Enum.Parse<MyOptions>(mySelection.ToString());
        total += roundScore;
    }

    return total;
}

public enum MyOptions
{
    X = 1,
    Y = 2,
    Z = 3
}