using System;
using System.Collections.Generic;
using System.Net.Quic;

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

    List<string> felonies = new List<string>();
    List<string> sjukdomar = new List<string>();

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
        else if (age >= 7 && age <= 12)
        {
            Thread.Sleep(1000);
            RandomEventPrimarySchool(random);
        }
        else if (age >= 13 && age <= 17)
        {
            Thread.Sleep(1000);
            RandomEventTeen(random);
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

        Console.WriteLine("Felonies:");
        foreach (string felony in felonies)
        {
            Console.WriteLine("  " + felony);
        }

        Console.WriteLine("Sjukdomar/Diagnoser:");
        foreach (string sjukdom in sjukdomar)
        {
            Console.WriteLine("  " + sjukdom);
        }

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
            ConsoleKeyInfo buttonPressed = Console.ReadKey(true); // kollar konstant vilken tangent som är tryckt
            if (buttonPressed.Key == ConsoleKey.Spacebar) { player.ageUp(random); }
        }

        Console.ReadLine();
    }

    void RandomEventPreschool(Random random)
    {
        int eventIndex = random.Next(0, 11);
        switch (eventIndex)
        {
            case 0:
                Console.WriteLine("\nDu ser en klasskamrat rita på väggen med kritor. Vad gör du?");
                Console.WriteLine("1. Säger till en lärare");
                Console.WriteLine("2. Ignorerar det och fortsätter leka");
                break;
            case 1:
                Console.WriteLine("\nDu hittar en bok med spännande bilder i skolbiblioteket. Vad gör du?");
                Console.WriteLine("1. Bläddrar i den och försöker förstå berättelsen");
                Console.WriteLine("2. Lägger tillbaka den och går och leker istället");
                break;
            case 2:
                Console.WriteLine("\nEn äldre elev utmanar dig att springa över vägen utan att se dig för. Vad gör du?");
                Console.WriteLine("1. Gör som de säger och springer över vägen");
                Console.WriteLine("2. Vägrar och går därifrån");
                break;
            case 3:
                Console.WriteLine("\nDu ser en liten kattunge ensam på gatan. Vad gör du?");
                Console.WriteLine("1. Försöker lyfta upp den och ta hem den");
                Console.WriteLine("2. Berättar för en vuxen");
                break;
            case 4:
                Console.WriteLine("\nDu får en svår fråga från din lärare. Vad gör du?");
                Console.WriteLine("1. Försöker svara även om du är osäker");
                Console.WriteLine("2. Säger ingenting och hoppas att läraren går vidare");
                break;
            case 5:
                Console.WriteLine("\nDu klättrar i ett träd på skolgården och kommer högt upp. Vad gör du?");
                Console.WriteLine("1. Försöker klättra ännu högre");
                Console.WriteLine("2. Klättrar försiktigt ner");
                break;
            case 6:
                Console.WriteLine("\nEn kompis erbjuder dig en liten bit godis du aldrig sett förut. Vad gör du?");
                Console.WriteLine("1. Äter det direkt");
                Console.WriteLine("2. Frågar en vuxen om det först");
                break;
            case 7:
                Console.WriteLine("\nDu hittar en rolig tecknad serie i tidningen. Vad gör du?");
                Console.WriteLine("1. Försöker läsa den och förstå historien");
                Console.WriteLine("2. Bläddrar förbi och tittar bara på bilderna");
                break;
            case 8:
                Console.WriteLine("\nDet ligger en stor pöl med vatten på skolgården. Vad gör du?");
                Console.WriteLine("1. Hoppar i den för att se hur det känns");
                Console.WriteLine("2. Går runt den för att inte bli blöt");
                break;
            case 9:
                Console.WriteLine("\nDu hittar en liten burk med vätska bakom skolan. Vad gör du?");
                Console.WriteLine("1. Öppnar den och luktar på den");
                Console.WriteLine("2. Lämnar den och berättar för en vuxen");
                break;
        }

        char choice = Console.ReadKey(true).KeyChar;
        Console.Clear();

        switch (eventIndex)
        {
            case 0:
                if (choice == '1')
                {
                    Console.WriteLine("Läraren tackade dig för att du sa till. (+2 intelligence)");
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du ignorerade det, men läraren blev arg när hen såg det. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 1:
                if (choice == '1')
                {
                    Console.WriteLine("Du lärde dig nya ord och blev mer nyfiken. (+3 intelligence)");
                    intelligence += 3;
                }
                else
                {
                    Console.WriteLine("Du missade chansen att lära dig något nytt. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 2:
                if (choice == '1')
                {
                    Console.WriteLine("Du blev påkörd av en bil och dog. Spelet är slut.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Du gjorde ett smart val och höll dig säker. (+2 intelligence, +2 health)");
                    intelligence += 2;
                    health += 2;
                }
                break;
            case 3:
                if (choice == '1')
                {
                    Console.WriteLine("Kattungen rev dig och du fick ett litet sår. (-2 health)");
                    health -= 2;
                }
                else
                {
                    Console.WriteLine("En vuxen hjälpte kattungen och du lärde dig vikten av ansvar. (+2 intelligence)");
                    intelligence += 2;
                }
                break;
            case 4:
                if (choice == '1')
                {
                    Console.WriteLine("Du försökte svara och lärde dig något nytt. (+2 intelligence)");
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du lärde dig ingenting den här gången. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 5:
                if (choice == '1')
                {
                    Console.WriteLine("Du tappade greppet och föll ner! (-3 health)");
                    health -= 3;
                }
                else
                {
                    Console.WriteLine("Du klättrade försiktigt ner och undvek skador. (+1 intelligence, +1 health)");
                    intelligence += 1;
                    health += 1;
                }
                break;
            case 6:
                if (choice == '1')
                {
                    Console.WriteLine("Godiset var gammalt och du fick ont i magen. (-3 health)");
                    health -= 3;
                }
                else
                {
                    Console.WriteLine("Vuxna sa att godiset var olämpligt. Du undvek en fara! (+2 intelligence)");
                    intelligence += 2;
                }
                break;
            case 7:
                if (choice == '1')
                {
                    Console.WriteLine("Du lärde dig mer om berättelser och text. (+2 intelligence)");
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du fokuserade bara på bilderna och missade historien. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 8:
                if (choice == '1')
                {
                    Console.WriteLine("Dina kläder blev blöta och du frös hela dagen. (-2 health)");
                    health -= 2;
                }
                else
                {
                    Console.WriteLine("Du höll dig torr och bekväm. (+1 intelligence, +1 health)");
                    intelligence += 1;
                    health += 1;
                }
                break;
            case 9:
                if (choice == '1')
                {
                    Console.WriteLine("Vätskan var giftig och du blev allvarligt sjuk! (-5 health)");
                    health -= 5;
                    if (health <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Du dog av förgiftning. Spelet är slut.");
                        Console.ReadLine();
                        Environment.Exit(0);

                    }
                }
                else
                {
                    Console.WriteLine("En vuxen tog hand om burken och du undvek en farlig situation. (+2 intelligence)");
                    intelligence += 2;
                }
                break;
        }
    }

    void RandomEventPrimarySchool(Random random)
    {
        int eventIndex = random.Next(0, 11);
        switch (eventIndex)
        {
            case 0:
                Console.WriteLine("\nDin lärare frågar om du vill presentera inför klassen. Vad gör du?");
                Console.WriteLine("1. Acceptera och träna på att tala inför folk");
                Console.WriteLine("2. Avböja och hålla dig i bakgrunden");
                break;
            case 1:
                Console.WriteLine("\nDu hittar en borttappad femtiolapp på skolgården. Vad gör du?");
                Console.WriteLine("1. Ge den till en lärare");
                Console.WriteLine("2. Behålla den själv");
                break;
            case 2:
                Console.WriteLine("\nEn klasskamrat ber dig om hjälp med läxan. Vad gör du?");
                Console.WriteLine("1. Hjälper till och förklarar");
                Console.WriteLine("2. Säger att du är för upptagen");
                break;
            case 3:
                Console.WriteLine("\nDu får chansen att gå med i skolans schackklubb. Vad gör du?");
                Console.WriteLine("1. Gå med och utveckla din strategi");
                Console.WriteLine("2. Tacka nej och fokusera på annat");
                break;
            case 4:
                Console.WriteLine("\nDin vän vill fuska på ett prov och ber dig hjälpa till. Vad gör du?");
                Console.WriteLine("1. Vägrar och står upp för ärlighet");
                Console.WriteLine("2. Hjälper till för att hålla vänskapen");
                break;
            case 5:
                Console.WriteLine("\nDet är idrottsdag och du kan välja mellan fotboll och löpning. Vad väljer du?");
                Console.WriteLine("1. Fotboll för att stärka lagkänslan");
                Console.WriteLine("2. Löpning för att testa din uthållighet");
                break;
            case 6:
                Console.WriteLine("\nDu blir inbjuden till en födelsedagsfest. Vad gör du?");
                Console.WriteLine("1. Går dit och skapar nya vänskaper");
                Console.WriteLine("2. Stannar hemma för att undvika social press");
                break;
            case 7:
                Console.WriteLine("\nEn ny elev börjar i klassen och verkar blyg. Vad gör du?");
                Console.WriteLine("1. Pratar med dem och inkluderar dem i gruppen");
                Console.WriteLine("2. Låter dem vara ifred");
                break;
            case 8:
                Console.WriteLine("\nDu får en skoluppgift där du ska skriva om din största dröm. Vad gör du?");
                Console.WriteLine("1. Skriver entusiastiskt och visar din ambition");
                Console.WriteLine("2. Slösar tid och lämnar in något halvdant");
                break;
            case 9:
                Console.WriteLine("\nDu hamnar i ett bråk på skolgården. Vad gör du?");
                Console.WriteLine("1. Försöker lugna ner situationen");
                Console.WriteLine("2. Blir arg och slåss tillbaka");
                break;
        }

        char choice = Console.ReadKey(true).KeyChar;
        Console.Clear();

        switch (eventIndex)
        {
            case 0:
                if (choice == '1')
                {
                    Console.WriteLine("Du tog chansen och förbättrade ditt självförtroende! (+3 intelligence)");
                    intelligence += 3;
                }
                else
                {
                    Console.WriteLine("Du undvek utmaningen men kanske missade en möjlighet. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 1:
                if (choice == '1')
                {
                    Console.WriteLine("Du gjorde det rätta och blev respekterad. (+2 intelligence, +1 wealth)");
                    intelligence += 2;
                    wealth += 1;
                }
                else
                {
                    Console.WriteLine("Du behöll pengarna, men hade lite dåligt samvete. (+5 wealth, -2 intelligence)");
                    wealth += 5;
                    intelligence -= 2;
                }
                break;
            case 2:
                if (choice == '1')
                {
                    Console.WriteLine("Du hjälpte en vän och stärkte din förståelse. (+2 intelligence)");
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du valde att inte hjälpa, men kanske missade en lärorik stund. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 3:
                if (choice == '1')
                {
                    Console.WriteLine("Du gick med i klubben och tränade ditt strategiska tänkande! (+3 intelligence)");
                    intelligence += 3;
                }
                else
                {
                    Console.WriteLine("Du tackade nej och fokuserade på andra saker.");
                }
                break;
            case 4:
                if (choice == '1')
                {
                    Console.WriteLine("Du stod upp för rättvisa! (+2 intelligence, +2 health)");
                    intelligence += 2;
                    health += 2;
                }
                else
                {
                    Console.WriteLine("Du hjälpte till att fuska, men kände dig osäker efteråt. (-2 intelligence)");
                    intelligence -= 2;
                }
                break;
            case 5:
                if (choice == '1')
                {
                    Console.WriteLine("Du spelade fotboll och blev bättre på att samarbeta! (+2 health, +2 intelligence)");
                    health += 2;
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du valde löpning och ökade din uthållighet. (+3 health)");
                    health += 3;
                }
                break;
            case 6:
                if (choice == '1')
                {
                    Console.WriteLine("Du gick på festen och utvecklade din sociala kompetens. (+2 intelligence, +1 looks)");
                    intelligence += 2;
                    looks += 1;
                }
                else
                {
                    Console.WriteLine("Du stannade hemma och kände dig kanske lite ensam. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 7:
                if (choice == '1')
                {
                    Console.WriteLine("Du tog initiativ och fick en ny vän. (+2 intelligence)");
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du lät den nya eleven vara, kanske missade du en vänskap.");
                }
                break;
            case 8:
                if (choice == '1')
                {
                    Console.WriteLine("Du skrev med passion och lärde dig om dina egna drömmar. (+3 intelligence)");
                    intelligence += 3;
                }
                else
                {
                    Console.WriteLine("Du slarvade och fick ett lågt betyg. (-2 intelligence)");
                    intelligence -= 2;
                }
                break;
            case 9:
                if (choice == '1')
                {
                    Console.WriteLine("Du löste bråket och blev en förebild. (+2 intelligence, +1 health)");
                    intelligence += 2;
                    health += 1;
                }
                else
                {
                    Console.WriteLine("Du hamnade i slagsmål och fick ett blåmärke. (-2 health)");
                    health -= 2;
                }
                break;
        }
    }

    void RandomEventTeen(Random random)
    {
        int eventIndex = random.Next(0, 11);
        switch (eventIndex)
        {
            case 0:
                Console.WriteLine("\nDina kompisar erbjuder dig en cigarett. Vad gör du?");
                Console.WriteLine("1. Rök arslet av dig, man lever ju ändå bara en gång ;)");
                Console.WriteLine("2. Avböj och gå till kyrkan");
                break;
            case 1:
                Console.WriteLine("\nNågon i klassen bli brutalt jävla mobbad. Vad gör du?");
                Console.WriteLine("1. Häng ut skitungen");
                Console.WriteLine("2. Tjalla");
                break;
            case 2:
                Console.WriteLine("\nEn klasskamrat ber dig om hjälp med läxan. Vad gör du?");
                Console.WriteLine("1. Hjälper till och förklarar");
                Console.WriteLine("2. Säger att du är för upptagen");
                break;
            case 3:
                Console.WriteLine("\nDu får chansen att fuska på ett prov. Vad gör du?");
                Console.WriteLine("1. Avvakta och svara på frågorna själv");
                Console.WriteLine("2. JA nu kör vi");
                break;
            case 4:
                Console.WriteLine("\nDu går till ICA med några polare. Vad köper du?");
                Console.WriteLine("1. En cola zero och en banan");
                Console.WriteLine("2. En stor pizzaslice, 2 redbulls, en marabou, 3 daimstrutar, en aladin chokladask, 7 klubbor, 4 godispåsar, ett sexpack med ölburkar, fem proteinbars och en gurka");
                break;
            case 5:
                Console.WriteLine("\nIdag så är du ensam hemma. Vad väljer du att göra?");
                Console.WriteLine("1. Städa, diska, laga en hälsosam måltid");
                Console.WriteLine("2. Ställa till med en megafest");
                break;
            case 6:
                Console.WriteLine("\n.Vad gör du?");
                Console.WriteLine("1. Springer ut i skogen och gråter");
                Console.WriteLine("2. Lever vidare ditt liv utan att springa ut i skogen och gråta");
                break;
            case 7:
                Console.WriteLine("\nEn Karen på COOP hävdar att du inte borde äta kött för att det är dåligt för miljön. Vad gör du?");
                Console.WriteLine("1. Slår ihjäl henne med en köttbit");
                Console.WriteLine("2. Låter henne vara ifred");
                break;
            case 8:
                Console.WriteLine("\nDu får en skoluppgift där du ska skriva om din största dröm. Vad gör du?");
                Console.WriteLine("1. Skriver entusiastiskt och visar din ambition");
                Console.WriteLine("2. Slösar tid och lämnar in något halvdant");
                break;
            case 9:
                Console.WriteLine("\nEn mystisk man försöker sälja droger till dig på gatan. Vad gör du?");
                Console.WriteLine("1. DAGS att shoppa, am I right?");
                Console.WriteLine("2. Ringer polisen");
                break;
        }
        char choice = Console.ReadKey(true).KeyChar;
        Console.Clear();

        switch (eventIndex)
        {
            case 0:
                if (choice == '1')
                {
                    Console.WriteLine("Du har utvecklat ett rökberoende och lider nu av lungcancer");
                    sjukdomar.Add("Lungcancer");
                }
                else
                {
                    Console.WriteLine("Du har precis undvikit lungcancer");
                }
                break;
            case 1:
                if (choice == '1')
                {
                    Console.WriteLine("Läraren blir arg på dig och du skickas ut i frontlinjen i Ukraina");
                    // Frontline Ukraine
                }
                else
                {
                    Console.WriteLine("Nu är du också mobbad, undvik mobbare i följande spel");
                    // Undvik mobbare
                }
                break;
            case 2:
                if (choice == '1')
                {
                    Console.WriteLine("Du hjälpte en vän och stärkte din förståelse. (+2 intelligence)");
                    intelligence += 2;
                }
                else
                {
                    Console.WriteLine("Du valde att inte hjälpa, men kanske missade en lärorik stund. (-1 intelligence)");
                    intelligence -= 1;
                }
                break;
            case 3:
                if (choice == '1')
                {
                    Console.WriteLine("Dtt betyg blev jävligt dåligt, men du fuskade i alla fall inte");
                }
                else
                {
                    Console.WriteLine("Din lärare kom på dig och du skickas nu till frontlinjen i Ukraina");
                    // Frontline Ukraine
                }
                break;
            case 4:
                if (choice == '1')
                {
                    Console.WriteLine("Du har undvikit socker och har nu fått i dig vitaminer (+2 health)");
                    health += 2;
                }
                else
                {
                    if (sjukdomar.Contains("Diabetes"))
                    {
                        // Spelaren dör
                    }
                    else
                    {
                        sjukdomar.Add("Diabetes");
                        Console.WriteLine("Grattis, du lider nu av diabetes");
                    }
                }
                break;
            case 5:
                if (choice == '1')
                {
                    Console.WriteLine("Dina föräldrar är stolta över dig (+500 SEK)");
                    wealth += 500;
                }
                else
                {
                    Console.WriteLine("Polisen tillkallas och du spenderar natten i fyllecellen");
                    felonies.Add("En natt i fyllecellen");
                }
                break;
            case 6:
                if (choice == '1')
                {
                    Console.WriteLine("Okej, najs");
                }
                else
                {
                    Console.WriteLine("Okej, najs");
                }
                break;
            case 7:
                if (choice == '1')
                {
                    Console.WriteLine("Polisen tar dig på bar gärning och du får ett fängelsestraff på 30 år");
                    age += 30;
                    felonies.Add("Dråp");
                }
                else
                {
                    Console.WriteLine("Det hela var ett test och du har blivit belönad med en massa jävla cash. (+5000 wealth)");
                }
                break;
            case 8:
                if (choice == '1')
                {
                    Console.WriteLine("Du skrev med passion och lärde dig om dina egna drömmar. (+3 intelligence)");
                    intelligence += 3;
                }
                else
                {
                    Console.WriteLine("Du slarvade och fick ett lågt betyg. (-2 intelligence)");
                    intelligence -= 2;
                }
                break;
            case 9:
                if (choice == '1')
                {
                    Console.WriteLine("Det var tyvärr inga riktiga droger (-2000 wealth)");
                    wealth -= 2000;
                }
                else
                {
                    Console.WriteLine("Personen hamnade i finkan och du undvek ett potentiellt fängelsestraff");
                }
                break;
        }

    }
}

