// See https://aka.ms/new-console-template for more information
var input = File.ReadAllLines("./input.txt");
var result = new List<int>();

var numberInWords = new Dictionary<string, char>
{
   { "one", '1' },
   { "two", '2' },
   { "three", '3' },
   { "four", '4' },
   { "five", '5' },
   { "six", '6' },
   { "seven", '7' },
   { "eight", '8' },
   { "nine", '9' },
   { "1", '1' },
   { "2", '2' },
   { "3", '3' },
   { "4", '4' },
   { "5", '5' },
   { "6", '6' },
   { "7", '7' },
   { "8", '8' },
   { "9", '9' },
};


char FindFirstNumber(string line)
{
   var (index, value) = (int.MaxValue, 'a');
   foreach (var number in numberInWords)
   {
      var found = line.IndexOf(number.Key);
      if(found < 0) continue;
      if (found >= index) continue;
      
      index = found;
      value = number.Value;
   }

   return value;
}

char FindLastNumber(string line)
{
   var (index, value) = (int.MinValue, 'a');
   foreach (var number in numberInWords)
   {
      var found = line.LastIndexOf(number.Key);
      if(found < 0) continue;
      if (found < index) continue;
      
      index = found;
      value = number.Value;
   }

   return value;
}

foreach (var line in input)
{
   var first = FindFirstNumber(line);
   var last = FindLastNumber(line);
   result.Add(int.Parse($"{first}{last}"));
}

Console.WriteLine($"{result.Sum()}");