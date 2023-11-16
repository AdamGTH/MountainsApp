
using MyMountainApp;

Console.WriteLine("========================================");
Console.WriteLine(" Witaj w aplikacji o górskich szlakach");
Console.WriteLine("========================================");

HashSet<string> ListOfTrails = new HashSet<string>();
//MTrailsInFile Trailx =  new MTrailsInFile("Połonina Wetlińska (Chatka Puchatka) z Przełęczy Wyżnej", ReadTextFromFile("./opisy/wetlina.txt"), "Wetlina", 2500);
//Trailx.DifficultyLevel(2);
//Trailx.DifficultyLevel(4.4);
//Trailx.DifficultyLevel(4.7);
//var stat = new Statistics();
//stat = Trailx.GetStatistics();
//Console.WriteLine($"Sum: {stat.Sum:N2}");
//Console.WriteLine($"Min: {stat.Min}");
//Console.WriteLine($"Max: {stat.Max}");
//Console.WriteLine($"Average: {stat.Average:N1}");
//MTrailsInFile Trail2 = new MTrailsInFile("Szlak z Krościenka na Sokolicę w Pieninach", ReadTextFromFile("./opisy/sokolica.txt"), "Krościenko", 3500);
//Trail2.DifficultyLevel(3.5);
//Trail2.DifficultyLevel(3.5);
//Trail2.DifficultyLevel(2);
//Trail2.DifficultyLevel(5);
//MTrailsInFile Trail3 = new MTrailsInFile("Trasa na Śnieżkę z Karpacza przez Samotnię i Strzechę Akademicką", ReadTextFromFile("./opisy/karpacz.txt"), "Karpacz", 8900);
//Trail3.DifficultyLevel(2);
//Trail3.DifficultyLevel(4.4);
//Trail3.DifficultyLevel(4.7);
while (true)
{
    Console.WriteLine("1. Otwóż zapisane szlaki");
    Console.WriteLine("2. Dodaj kolejne szlaki");
    Console.WriteLine("'q' -  kończy program");
    var read = Console.ReadLine();

    if (read == "1")
    {
        int numOfTrails = ShowTrailsList();
        Console.WriteLine("'q' - wyjdź");
        read = Console.ReadLine();
        int idx = int.Parse(read);

        if (read == "q") continue;
        else if(idx <= numOfTrails && idx > 0) 
        {
            ShowTrail(ListOfTrails, idx);
        }
        else
        {
            Console.WriteLine("Value is not correct");
            continue;
        }
    }
    else if (read == "2")
    {
        Console.WriteLine("Dodawanie");
        continue;
    }
    else if (read == "q")
    {
        Console.WriteLine("Koniec programu");
        break;
    }
    else continue;
}
void EventAdd(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Grade is added");
    Console.ForegroundColor= ConsoleColor.White;
}

string ReadTextFromFile(string fileName)
{
    string desc = "";
    if(File.Exists(fileName))
    {
        using(StreamReader sr = new StreamReader(fileName)) 
        {
            desc = sr.ReadToEnd();
        }
    }
    else
    {
        Console.WriteLine("File is not exist !!!");
    }
    return desc;
}

void ReadTrails(string fileName)
{
    
    if (File.Exists(fileName))
    {
        using (var reader = File.OpenText(fileName))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                ListOfTrails.Add(line);
                line = reader.ReadLine() ;
                  
            }
        }
    }
    else
    {
        Console.WriteLine("File is not exist !!!");
    }
    
}

int ShowTrailsList()
{
    int count = 1;
    Console.WriteLine("Otwieranie");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    ReadTrails("ListOfNames.txt");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var item in ListOfTrails)
    {
        Console.WriteLine($"{count} - {item}");
        count++;
    }
    return count - 1;
}

void ShowTrail(HashSet<string> list, int idx)
{
    var fileName = "";
    int i = 0;
    foreach (var item in list)
    {
        fileName = item;
        if(i++ == (idx-1))
        {
            break;
        }
    }
    using(var reader = File.OpenText($"{fileName}.txt"))
    {
        var line = reader.ReadLine();
        while (line != null)
        {
            Console.WriteLine(line);
            line = reader.ReadLine();
        }
    }
}