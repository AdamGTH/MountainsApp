
using MyMountainApp;

Console.WriteLine("========================================");
Console.WriteLine(" Witaj w aplikacji o górskich szlakach");
Console.WriteLine("========================================");

MTrailsInFile Trailx =  new MTrailsInFile("Połonina Wetlińska (Chatka Puchatka) z Przełęczy Wyżnej", ReadTextFromFile("ExampleDescr.txt"), "Wetlina", 2500);
Trailx.DifficultyLevel(4);
Trailx.DifficultyLevel(4.4);
Trailx.DifficultyLevel(4.7);
//while(true)
//{
//    Console.WriteLine("1. Otwóż zapisane szlaki");
//    Console.WriteLine("2. Dodaj kolejne szlaki");
//    Console.WriteLine("'q' kończy program");
//    var read = Console.ReadLine();

//    if (read == "1")
//    {
//        Console.WriteLine("Otwieranie");
//        Console.WriteLine();
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine(ReadTextFromFile("ExampleDescr.txt"));
//        Console.ForegroundColor = ConsoleColor.White;
//    }
//    else if (read == "2")
//    {
//        Console.WriteLine("Dodawanie");
//        continue;
//    }
//    else if (read == "q")
//    {
//        Console.WriteLine("Koniec programu");
//        break;
//    }
//    else continue;
//}
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
