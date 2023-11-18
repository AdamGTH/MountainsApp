
using MyMountainApp;

Console.WriteLine("========================================");
Console.WriteLine(" Witaj w aplikacji o górskich szlakach");
Console.WriteLine("========================================");

HashSet<string> ListOfTrailsNames = new HashSet<string>();
List<MTrailsInMemory> ListOfTrails = new List<MTrailsInMemory>();

ReadTrails();

while (true)
{
    Console.WriteLine("\n1. Otwóż zapisane szlaki");
    Console.WriteLine("2. Dodaj nowy szlak górski");
    Console.WriteLine("'q' -  kończy program");
    var read = Console.ReadLine();

    if (read == "1")
    {
        int idx = 0;
        ShowTrailsList();
        Console.WriteLine("'q' - wyjdź");
        read = Console.ReadLine();
        if (int.TryParse(read, out var intValue))
        {
            idx = intValue;
        }

        if (read == "q") 
        {
            continue;
        } 
        else if(idx <= ListOfTrails.Count && idx > 0) 
        {
            ShowTrail(idx-1);
        }
        else
        {
            Console.WriteLine("Value is not correct");
            continue;
        }
    }
    else if (read == "2")
    {
        addTrail();
        continue;
    }
    else if (read == "q")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        SaveTrails();
        Console.WriteLine("Program został poprawnie zamknięty");
        Console.ForegroundColor= ConsoleColor.White;
        break;
    }
    else continue;
}
void EventAddedGrade(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nGrade is added");
    Console.ForegroundColor= ConsoleColor.White;
}

void ReadTrails()
{
    string name = "";
    string description = "";
    string place = "";
    int lenght = 0;
    List<string> grades = new List<string>();

    ListOfTrailsNames = ReadTrailsNames("ListOfNames.txt");

    foreach(var trail in  ListOfTrailsNames)
    {
        name = trail;
        using(var reader = File.OpenText($"{trail}.txt"))
        {
            var line = reader.ReadLine();
            while(line != null)
            {
                if(line == "Place:")
                {
                    place = reader.ReadLine();
                    
                }
                else if (line == "Description:")
                {
                    description = reader.ReadLine();
                }
                else if(line == "Lenght of the meters:")
                {
                    lenght = int.Parse(reader.ReadLine());
                }
                else if(line == "Grades:")
                {
                    while(line != null)
                    {
                        line = reader.ReadLine();
                        grades.Add(line);
                    }
                }
                line = reader.ReadLine();
            }
                        
        }
        MTrailsInMemory trailInMemo = new MTrailsInMemory(name, description, place, lenght);
        for(int i = 0; i<grades.Count; i++)
        {
            try
            {
                trailInMemo.DifficultyLevel(grades[i]);
                grades[i] = null;
            }
            catch (Exception ex)
            {
                continue;
            }
                      
        }
        
        trailInMemo.GradeAdded += EventAddedGrade;
        ListOfTrails.Add(trailInMemo);
    }
}

HashSet<string> ReadTrailsNames(string fileName)
{
    HashSet<string> trails = new HashSet<string>();
    if (File.Exists(fileName))
    {
        using (var reader = File.OpenText(fileName))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                trails.Add(line);
                line = reader.ReadLine() ;
                  
            }
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Nie znaleziono listy zapisanych szlaków. Dodaj nowy szlak");
        Console.ForegroundColor = ConsoleColor.White;
    }
    return trails;
}

void ShowTrailsList()
{
    int count = 1;
   
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n\nAktualna lista zapisanych szlaków:");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var item in ListOfTrails)
    {
        Console.WriteLine($"{count} - {item.TrailName}");
        count++;
    }
}

void ShowTrail(int idx)
{
    Statistics statistics = new Statistics();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Nazwa szlaku:");
    Console.WriteLine($"{ListOfTrails[idx].TrailName}\n");
    Console.WriteLine("Miejsce:");
    Console.WriteLine($"{ListOfTrails[idx].TrailPlace}\n");
    Console.WriteLine("Opis:");
    Console.WriteLine($"{ListOfTrails[idx].TrailDescription}\n");
    Console.WriteLine("Oceny trudności:");
    foreach(var grad in ListOfTrails[idx].Grades)
    {
        Console.WriteLine($"{grad}");
    }

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nDodaj swoją ocenę trudności szlaku w skali od 1 do 5 i wyświetl statystyki: ");
    Console.WriteLine("'q' - wyjdź");
    var gradeString = Console.ReadLine();
    if (float.TryParse(gradeString, out var grade))
    {
        try
        {
            ListOfTrails[idx].DifficultyLevel(grade);
            statistics = ListOfTrails[idx].GetStatistics();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Maksymalna ocena: {statistics.Max}");
            Console.WriteLine($"Minimalna ocena: {statistics.Min}");
            Console.WriteLine($"Średnia: {statistics.Average}");
            Console.WriteLine($"Poziom trudności: {statistics.AverageString}");
            Console.ForegroundColor= ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

void addTrail()
{
    Statistics statistics = new Statistics();
    Console.WriteLine("Podaj nazwę szlaku: ");
    string name = Console.ReadLine();
    Console.WriteLine("Podaj miejsce szlaku: ");
    string place = Console.ReadLine();
    Console.WriteLine("Podaj długość szlaku w metrach: ");
    string lenghtString = Console.ReadLine();
    int lenghtInt = 0;
    if (int.TryParse(lenghtString, out var result)) 
    {
        lenghtInt = result;
    }
    Console.WriteLine("Opisz szlak: ");
    string description = Console.ReadLine();

    MTrailsInMemory newTrailInMemory = new MTrailsInMemory(name, description, place, lenghtInt);
    MTrailsInFile newTrailInFile = new MTrailsInFile(name, description, place, lenghtInt);
    newTrailInFile.AddtoListOfNamesToFile();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Nowy szlak został dodany !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nDodaj swoją ocenę trudności szlaku w skali od 1 do 5 i wyświetl statystyki: ");
    Console.WriteLine("'q' - wyjdź");
    var gradeString = Console.ReadLine();
    if (gradeString == "q")
    {
        ListOfTrails.Add(newTrailInMemory);
        return;
    }
    if (float.TryParse(gradeString, out var grade))
    {
        try 
        {
            newTrailInMemory.DifficultyLevel(grade);
            statistics = newTrailInMemory.GetStatistics();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Maksymalna ocena: {statistics.Max}");
            Console.WriteLine($"Minimalna ocena: {statistics.Min}");
            Console.WriteLine($"Ilość ocen: {statistics.Count}");
            Console.WriteLine($"Średnia: {statistics.Average}");
            Console.WriteLine($"Poziom trudności: {statistics.AverageString}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    ListOfTrails.Add(newTrailInMemory);
    
}

void SaveTrails()
{
    foreach(var trail in ListOfTrails)
    {
        MTrailsInFile trailFile = new MTrailsInFile(trail.TrailName, trail.TrailDescription, trail.TrailPlace, trail.LenghtOfTheTrail, trail.Grades);
    }
}