
using MyMountainApp;

Console.WriteLine("Witaj w aplikacji o górskich szlakach");
Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");

MTrailsInFile Trailx =  new MTrailsInFile("Szlak numer 1", "Szlak Górski w Bieszczadach...", "Wetlina", 125, 2000);
Trailx.GradeAdded += EventAdd;

Trailx.DifficultyLevel(4.5);
Trailx.DifficultyLevel(4);
Trailx.DifficultyLevel(3);

MTrailsInFile Traily = new MTrailsInFile("Szlak numer 2", "Szlak Górski w Bieszczadach...", "Smerek", 222, 1500);

Traily.DifficultyLevel(3);
Traily.DifficultyLevel(4);
Traily.DifficultyLevel(5);

Statistics statistics = new Statistics();
statistics = Trailx.GetStatistics();
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Sum: {statistics.Sum}");
Console.WriteLine($"Average: {statistics.Average}");
Console.WriteLine($"AverageString: {statistics.AverageString}");

//string opis = "był sobie taki opis";

//var cont = opis.IndexOf("opis");

//Console.WriteLine(cont);

void EventAdd(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Grade is added");
    Console.ForegroundColor= ConsoleColor.White;
}