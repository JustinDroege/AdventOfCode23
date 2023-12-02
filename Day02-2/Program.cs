// See https://aka.ms/new-console-template for more information

var lines = File
    .ReadAllLines("./input.txt")
    .Select(l => l.Split(":").Last())
    .ToArray();

const int maxRed = 12;
const int maxBlue = 14;
const int maxGreen = 13;

int result = 0;

for (var index = 0; index < lines.Length; index++)
{
    var flag = false;
    var atLeastRed = int.MinValue;
    var atLeastGreen = int.MinValue;
    var atLeastBlue = int.MinValue;
    
    foreach (var set in lines[index].Split(";"))
    {
        var colors = set.Split(",");
        foreach(var color in colors)
        {
            
            var tuple = color.Split(" ");
            switch (tuple[2].ToLower())
            {
                case "red":
                    if (int.Parse(tuple[1]) > atLeastRed)
                        atLeastRed = int.Parse(tuple[1]);
                    break;
                case "blue":
                    if (int.Parse(tuple[1]) > atLeastBlue)
                        atLeastBlue = int.Parse(tuple[1]);
                    break;
                case "green":
                    if (int.Parse(tuple[1]) > atLeastGreen)
                        atLeastGreen = int.Parse(tuple[1]);
                    break;
            }
        }
    }

    result += atLeastRed * atLeastBlue * atLeastGreen;
}


Console.WriteLine(result.ToString());
