// Hayden Wright
// 2024-09-08
// MIST-352-002
// In Class Assignment 2

using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's your Hero's name?");
        string heroName = Console.ReadLine();

        Console.WriteLine("What's your favorite place?");
        string favoritePlace = Console.ReadLine();

        Console.WriteLine("What's your lucky number?");
        string luckyNumberText = Console.ReadLine();

        heroName = heroName.Trim();
        favoritePlace = favoritePlace.Trim();

        // setting up the bool and int output for lucky number
        bool parsedOkay = int.TryParse(luckyNumberText, out int luckyNumber);

        string line1 = "Meet " + heroName.ToUpper() + "!";
        string line2 = "Today's quest starts in " + favoritePlace + ".";
        string line3 = "Lucky number: " + luckyNumber;

        // nickname sectionJoe
        string nick = "";
        if (heroName.Length > 0) nick += heroName[0];
        if (heroName.Length > 1) nick += heroName[1];
        if (heroName.Length > 2) nick += heroName[2];
        nick = nick.ToUpper();

        string code = "#" + nick + "-" + luckyNumber;

        string report = line1 + "\n" + line2 + "\n" + line3 + "\n" + "QuestCode: " + code;

        Console.WriteLine(report);
        Console.WriteLine("Parse success: " + parsedOkay);
        Console.WriteLine("Hero length: " + heroName.Length);
        Console.WriteLine("Place contains a space: " + (favoritePlace.IndexOf(" ") >= 0));
    }
}
