using System;
using System.Collections.Generic;

class person
{

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

    int wealth = 0; // spelarens pengar
    int salary = 0; // hur mycket spelaren tjänar varje år (efter skatt, allt från veckopeng till jobb)

    public person(Random random)
    {

        if (random.Next(0, 2) == 0)
        {
            firstName = firstNamesMale[random.Next(firstNamesMale.Count)];
            gender = "male";
        }
        else
        {
            firstName = firstNamesFemale[random.Next(firstNamesFemale.Count)];
            gender = "female";
        }

        lastName = lastNames[random.Next(lastNames.Count)];

        // genererar spelarens IQ och minskar risken för extremea värden
        if (random.Next(0, 4) == 0) { intelligence = random.Next(80, 100); } else { intelligence = random.Next(70, 120); }

        // genererar looks-poäng och minskar risken för extrema värden
        if (random.Next(0, 3) == 0) { looks = random.Next(10, 91); } else { looks = random.Next(40, 61); }

        // genererar hälsopoäng och minskar risken för extrema värden
        if (random.Next(0, 3) == 0) { health = random.Next(10, 91); } else { health = random.Next(70, 90); }
    }

    public void ageUp(Random random)
    {
        Console.Clear();
        age++;

        if (intelligenceDirection == "positive" && intelligence > 140 && age < 60) { if (random.Next(0, 2) == 1) { intelligence += random.Next(0, 2); } }
        else if (intelligenceDirection == "positive" && intelligence > 120 && age < 60) { intelligence += random.Next(0, 2); }
        else if (intelligenceDirection == "positive" && age < 60) { intelligence += random.Next(0, 6); }
        else if (intelligenceDirection == "positive" && age > 60 && age < 80) { intelligence += random.Next(-1, 2); }
        else { intelligence += random.Next(-3, 2); }

        if (looksDirection == "positive" && looks > 99) { looks = 100; }
        else if (looksDirection == "negative" && gender == "female" && age < 25) { looks += random.Next(-2, 2); }
        else if (age >= 25 && gender == "female") { looks += random.Next(-2, 2); }
        else if (looksDirection == "negative" && gender == "male" && age < 40) { looks += random.Next(-2, 4); }
        else if (age >= 45 && gender == "male") { looks += random.Next(-2, 2); }
        else if (looksDirection == "positive" && looks > 80) { looks += random.Next(0, 2); }
        else if (looksDirection == "positive") { looks += random.Next(0, 6); }

        if (healthDirection == "positive" && health > 99) { health = 100; }
        else if (healthDirection == "positive" && health > 80) { health += random.Next(0, 2); }
        else if (healthDirection == "positive") { health += random.Next(0, 6); }
        else { health -= random.Next(0, 6); }

        print_player_info();

        if (age >= 3 && age <= 6)
        {
            Thread.Sleep(1000);
            RandomEventPreschool(random);
        }
    }

    public void print_player_info()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Player info:");
        Console.WriteLine("   name: " + this.firstName + " " + this.lastName);
        Console.WriteLine("   gender: " + this.gender);
        Console.WriteLine("   age: " + this.age);
        Console.WriteLine("");

        Console.WriteLine("Statistics:");
        Console.WriteLine("   Intelligence: " + this.intelligence);
        Console.WriteLine("   Looks: " + this.looks);
        Console.WriteLine("   Health: " + this.health);
        Console.WriteLine("   Wealth: " + this.wealth + " SEK");
        Console.WriteLine("   Salary: " + this.salary + " SEK");
        Console.WriteLine("------------------\n\n\n");
    }

    static void Main(string[] args)
    {
        Random random = new Random();
        person player = new person(random);
        Console.CursorVisible = false;

        player.print_player_info();

        while (true)
        {
            Console.SetCursorPosition(0, 0);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo buttonPressed = Console.ReadKey(true); // kollar konstant vilken tangent som är tryckt
                if (buttonPressed.Key == ConsoleKey.Spacebar) { player.ageUp(random); }
            }
        }

        Console.ReadLine();
    }

    void RandomEventPreschool(Random random)
    {
        int eventIndex = random.Next(0, 11);
        switch (eventIndex)
        {
            case 0:
                Console.WriteLine("\nDin kompis Jörgen har tagit din hund. Vad gör du?");
                Console.WriteLine("1. Konfrontera Jörgen");
                Console.WriteLine("2. Försök förklara och lösa konflikten");
                break;
            case 1:
                Console.WriteLine("\nDu hittade en gammal låda på vinden. Vad gör du?");
                Console.WriteLine("1. Öppna den och se vad den innehåller");
                Console.WriteLine("2. Lämna den orörd");
                break;
            case 2:
                Console.WriteLine("\nEn granne ber om hjälp med att bära in möbler. Vad gör du?");
                Console.WriteLine("1. Hjälp till gärna");
                Console.WriteLine("2. Avböj artigt");
                break;
            case 3:
                Console.WriteLine("\nDu snubblade på trottoaren på väg till skolan. Vad gör du?");
                Console.WriteLine("1. Skaka av dig och fortsätt");
                Console.WriteLine("2. Sitt en stund och vila");
                break;
            case 4:
                Console.WriteLine("\nDu fann ett intressant objekt på marken. Vad gör du?");
                Console.WriteLine("1. Plocka upp det och undersök noga");
                Console.WriteLine("2. Lämna det och fortsätt gå");
                break;
            case 5:
                Console.WriteLine("\nDu hörde ett ovanligt ljud från skogen. Vad gör du?");
                Console.WriteLine("1. Gå och undersök ljudet");
                Console.WriteLine("2. Gå hem för att vara säker");
                break;
            case 6:
                Console.WriteLine("\nDin favoritapparat är trasig. Vad gör du?");
                Console.WriteLine("1. Försök laga den själv");
                Console.WriteLine("2. Berätta för en vuxen om problemet");
                break;
            case 7:
                Console.WriteLine("\nDu upptäckte ett litet rum i huset som du aldrig sett förut. Vad gör du?");
                Console.WriteLine("1. Gå in och utforska");
                Console.WriteLine("2. Låt det vara och fortsätt med dina sysslor");
                break;
            case 8:
                Console.WriteLine("\nEn vän föreslog en ny lek. Vad gör du?");
                Console.WriteLine("1. Prova leken direkt");
                Console.WriteLine("2. Föreslå en annan lek");
                break;
            case 9:
                Console.WriteLine("\nDu hittade en gammal penna som verkar speciell. Vad gör du?");
                Console.WriteLine("1. Testa att rita med den");
                Console.WriteLine("2. Lägg den åt sidan");
                break;
        }

        char choice = Console.ReadKey(true).KeyChar;
        Console.Clear();

        switch (eventIndex)
        {
            case 0:
                if (choice == '1')
                {
                    Console.WriteLine("Du konfronterade Jörgen och lärde dig om ansvar och konsekvenser. (+5 wealth, -3 health)");
                    wealth += 5;
                    health -= 3;
                }
                else
                {
                    Console.WriteLine("Du försökte lösa konflikten lugnt och utvecklade empati. (+3 intelligence)");
                    intelligence += 3;
                }
                break;
            case 1:
                if (choice == '1')
                {
                    Console.WriteLine("Du öppnade lådan och fann gamla minnen som stärkte din nyfikenhet. (+10 wealth, +2 intelligence)");
                    wealth += 10;
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du valde att lämna lådan, vilket gav dig tid för reflektion. (+1 intelligence, +1 health)");
                    intelligence += 1;
                    health += 1;
                }
                break;
            case 2:
                if (choice == '1')
                {
                    Console.WriteLine("Du hjälpte grannen och lärde dig värdet av samarbete. (+2 intelligence, +2 health)");
                    intelligence += 2;
                    health += 2;
                }
                else
                {
                    Console.WriteLine("Du avböjde hjälpen och insåg vikten av att sätta gränser. (-1 health)");
                    health -= 1;
                }
                break;
            case 3:
                if (choice == '1')
                {
                    Console.WriteLine("Du skakade av dig missödet och gick vidare med ökad självkänsla. (+2 intelligence, +1 health)");
                    intelligence += 2;
                    health += 1;
                }
                else
                {
                    Console.WriteLine("Du tog en paus för att vila, vilket gav dig tid att tänka. (-2 intelligence)");
                    intelligence -= 2;
                }
                break;
            case 4:
                if (choice == '1')
                {
                    Console.WriteLine("Du undersökte objektet och lärde dig om gamla traditioner. (+3 intelligence, +1 wealth)");
                    intelligence += 3;
                    wealth += 1;
                }
                else
                {
                    Console.WriteLine("Du lämnade objektet, vilket gav dig en lugn promenad. (+1 health)");
                    health += 1;
                }
                break;
            case 5:
                if (choice == '1')
                {
                    Console.WriteLine("Du utforskade skogen och fick en äkta känsla av äventyr. (+3 intelligence, +2 health)");
                    intelligence += 3;
                    health += 2;
                }
                else
                {
                    Console.WriteLine("Du gick hem, vilket ökade din känsla av trygghet. (+2 health)");
                    health += 2;
                }
                break;
            case 6:
                if (choice == '1')
                {
                    Console.WriteLine("Du försökte laga apparaten och utvecklade praktiska färdigheter. (+2 intelligence, +3 wealth)");
                    intelligence += 2;
                    wealth += 3;
                }
                else
                {
                    Console.WriteLine("Du informerade en vuxen och lärde dig om problemlösning. (+2 wealth, +1 salary)");
                    wealth += 2;
                    salary += 1;
                }
                break;
            case 7:
                if (choice == '1')
                {
                    Console.WriteLine("Du utforskade rummet och upptäckte familjens historia. (+3 intelligence, +2 wealth)");
                    intelligence += 3;
                    wealth += 2;
                }
                else
                {
                    Console.WriteLine("Du undrade över rummet men valde att inte störa. (+1 intelligence)");
                    intelligence += 1;
                }
                break;
            case 8:
                if (choice == '1')
                {
                    Console.WriteLine("Du provade den nya leken och lärde dig om socialt samspel. (+2 intelligence, +2 looks)");
                    intelligence += 2;
                    looks += 2;
                }
                else
                {
                    Console.WriteLine("Du föreslog en annan lek och utvecklade kreativ problemlösning. (+1 intelligence)");
                    intelligence += 1;
                }
                break;
            case 9:
                if (choice == '1')
                {
                    Console.WriteLine("Du ritade med pennan och fick en stund av kreativ inspiration. (+3 intelligence, +2 wealth)");
                    intelligence += 3;
                    wealth += 2;
                }
                else
                {
                    Console.WriteLine("Du lade pennan åt sidan, men reflekterade över dess potential. (+1 intelligence)");
                    intelligence += 1;
                }
                break;
        }

        Thread.Sleep(3000);
        Console.Clear();
        print_player_info();

    }
}

