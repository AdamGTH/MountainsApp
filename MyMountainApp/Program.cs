
using MyMountainApp;

string opis = "Jakie szlaki górskie dla początkujących koniecznie trzeba przejść? Jednym z nich jest zdecydowanie trasa na Szczeliniec Wielki. Ten najwyższy szczyt Gór Stołowych warto odwiedzić przynajmniej raz w życiu. Trasa jest łatwa, a przy tym bardzo widokowa. Dotarcie z Karłowa na Szczeliniec i obejście labiryntu skalnego według mapy zajmie ok. godziny. My jednak zalecamy zarezerwować sobie nieco więcej czasu, bo doskonale wiemy, że podziwianie widoków i robienie zdjęć na tarasach skalnych kusi każdego, kto tutaj dotrze";
string input = "";
Console.WriteLine("========================================");
Console.WriteLine(" Witaj w aplikacji o górskich szlakach");
Console.WriteLine("========================================");

MTrailsInFile mTrailsInFile = new MTrailsInFile("Trasa na Szczeliniec Wielki z Karłowa", opis, "Góry stołowe", 2800 );
mTrailsInFile.GradeAdded += GradesAdded;

while (true)
{
    Console.WriteLine("Podaj ocene trudności dla szlaku lub wciśnij 'q' aby wyjsc i wyswietlic statystyki");
    input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }
    try
    {
        mTrailsInFile.DifficultyLevel(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exeption catched: {ex.Message}");
    }

}
var statistics = mTrailsInFile.GetStatistics();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\nŚrednia: {statistics.Average:N2}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Suma ocen: {statistics.Sum}");
Console.ForegroundColor = ConsoleColor.White;
void GradesAdded(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Ocena została dodana poprawnie");
    Console.ForegroundColor= ConsoleColor.White;
}