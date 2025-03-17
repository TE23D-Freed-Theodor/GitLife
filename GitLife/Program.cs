using System.Runtime.CompilerServices;

class person {

    List<string> firstNamesMale = new List<string> { 
        "Theodor", "Filip", "Vincent" 
    };

    List<string> firstNamesFemale = new List<string> { 
        "Eva-Greta", "Gregorina", "Mullolina" 
    };

    List<string> lastNames = new List<string> {
        "Johansson", "Anderson", "Smith" 
    };

    string firstName;
    string lastName; // efternamnet som spelaren har

    string gender; // könet som spelaren har (male/female)

    int age = 0;

    int intelligence; // skala från 50 till 150 spelarens intelligens
    string intelligenceDirection = "positive";

    int looks; // skala från 1-100 spelarens utseende
    string looksDirection = "positive"; // om spelaren blir snyggare/fulare när den åldras

    int health; // skala från 1-100 spelarens hälsa
    string healthDirection = "positive"; // om spelaren blir mer/mindre hälsosam när den åldras

    int wealth = 0; // (i dollar) spelarens pengar
    int salary = 0; // hur mycket spelaren tjänar varje år (efter skatt, allt från veckopeng till jobb)

    public person(Random random) {

        if (random.Next(0, 2) == 0) {
            firstName = firstNamesMale[random.Next(firstNamesMale.Count)];
            gender = "male";
        }
        else {
            firstName = firstNamesFemale[random.Next(firstNamesFemale.Count)];
            gender = "female";
        }

        lastName = lastNames[random.Next(lastNames.Count)];

        // genererar spelarens IQ och minskar risken för extremea värden
        if (random.Next(0,4) == 0) {intelligence = random.Next(80, 100);} else {intelligence = random.Next(70, 120);}

        // genererar looks-poäng och minskar risken för extrema värden
        if (random.Next(0,3) == 0) {looks = random.Next(10, 91);} else {looks = random.Next(40, 61);}

        // genererar hälsopoäng och minskar risken för extrema värden
        if (random.Next(0,3) == 0) {health = random.Next(10, 91);} else {health = random.Next(70, 90);}
    }

    public void ageUp(Random random) {
        age++;

        if (intelligenceDirection == "positive") {intelligence += random.Next(0, 6);}
        else {intelligence -= random.Next(0, 6);}

        if (looksDirection == "positive") {looks += random.Next(0, 6);}
        else {looks -= random.Next(0, 6);}

        if (healthDirection == "positive") {health += random.Next(0, 6);}
        else {health -= random.Next(0, 6);}
    }

    static void Main(string[] args) {
        Random random = new Random();
        person player = new person(random); 
        Console.CursorVisible = false;

        while (true) {
            Console.SetCursorPosition(0, 0); 
            Console.WriteLine("------------------");
            Console.WriteLine("Player info:");
            Console.WriteLine("   name: " + player.firstName + " " + player.lastName);
            Console.WriteLine("   gender: " + player.gender);
            Console.WriteLine("   age: " + player.age);
            Console.WriteLine("");

            Console.WriteLine("Statistics:");
            Console.WriteLine("   Intelligence: " + player.intelligence);
            Console.WriteLine("   Looks: " + player.looks);
            Console.WriteLine("   Health: " + player.health);
            Console.WriteLine("   Wealth: " + player.wealth);
            Console.WriteLine("   Salary: " + player.salary);
            Console.WriteLine("------------------\n\n\n");
        
            if (Console.KeyAvailable) {
                ConsoleKeyInfo buttonPressed = Console.ReadKey(true); // kollar konstant vilken tangent som är tryckt
                if (buttonPressed.Key == ConsoleKey.Spacebar) {player.ageUp(random);}
            }
        }

        Console.ReadLine();
    }
}

