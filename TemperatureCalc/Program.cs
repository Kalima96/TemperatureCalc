namespace TemperatureCalc
{
    internal class Program 
    {
        static void Main(string[] args) 
        {
            //Arrayen själv är ett objekt, och varje plats i arrayen kan hålla ett objekt av typen Month
            Month[] DagariMaj = new Month[31];
            for (int i = 0; i < 31; i++)
            {
                //Index i startar på 0 pga en array och vi vill att första dagen ska heta "Dag 1", inte "Dag 0".
                //Så vi adderar i med +1 för att få det att börja på dag 1 med en interpolerad sträng
                DagariMaj[i] = new Month($"Dag {i + 1}"); //Month-objekt med en parameter $"Dag {i + 1}
            }

            //Val till alla user storys
            Console.WriteLine("Skriv A om du vill du se temperaturdata för varje dag i maj\nSkriv B om du vill veta medeltemperaturen i maj");
            Console.WriteLine("Skriv C om du vill hitta den dag i maj med högsta temperaturen och identifiera den varmaste dagen\nSkriv D om du vill hitta den dag i maj med lägsta temperaturen och identifiera den kallaste dagen");
            Console.WriteLine("Skriv E för att få fram mediantemperaturen för majmånad\nSkriv F om du vill sortera temperaturerna i stigande eller fallande ordning");
            Console.WriteLine("Skriv G om du vill filtrera de dagar då temperaturen överstiger en viss tröskelvärde\nSkriv H om du vill få reda på temperaturen i en dag samt få fram temperaturen för dagen efter och inann");
            Console.WriteLine("Skriv I om du vill få fram den vanligast förekommande temperaturen i maj");
            string answer = Console.ReadLine().ToLower();

            switch (answer)
            {
                case "a":
                    //itirerar över objekt i arrayen
                    Console.WriteLine("temperaturdata för varje dag i maj:");
                    foreach (var dag in DagariMaj)
                    {
                        Console.WriteLine($"{dag.Dagen}: {dag.Temp}°C"); //använder objektet 'dag'
                    }

                    break;



                case "b":
                    //Manuell beräkning av Medeltemperaturen baserad på gränserna 15-25
                    int kall = 15;
                    int varm = 25;
                    int Medeltemperaturen = (kall + varm) / 2;

                    Console.WriteLine($"medeltemperaturen i maj är {Medeltemperaturen}°C ");

                    break;



                case "c":

                    //Kollar om någon dag har temperaturen 25°C
                    bool finnsTemperatur25 = false;

                    foreach (var dag in DagariMaj)
                    {
                        if (dag.Temp == 25) // Jämförelseoperatorn "== lika med"
                        {
                            Console.WriteLine($"{dag.Dagen} har temperaturen 25°C. Varamaste dagen");
                            finnsTemperatur25 = true;
                        }
                    }

                    if (!finnsTemperatur25)
                    {
                        Console.WriteLine("Ingen dag i maj har temperaturen 25°C");
                    }

                    break;



                case "d":

                    //Kollar om någon dag har temperaturen 15°C
                    bool finnsTemperatur15 = false;

                    foreach (var dag in DagariMaj)
                    {
                        if (dag.Temp == 15)
                        {
                            Console.WriteLine($"{dag.Dagen} har temperaturen 15°C. kallaste dagen");
                            finnsTemperatur15 = true;
                        }

                    }

                    if (!finnsTemperatur15)
                    {
                        Console.WriteLine("Ingen dag i maj har temperaturen 15°C.");
                    }

                    break;



                case "e":

                    Console.WriteLine("mediantemperaturen i maj är 20°C ");


                    break;



                case "f":
                    //Sorterar temperaturerna i stigande eller fallande ordning med variatoner av .OrderBy och .ToList
                    Console.WriteLine("Vill du ha temperaturerna i stigande eller fallande ordning? (Skriv 'stigande' eller 'fallande')");
                    string ordning = Console.ReadLine().ToLower();

                    if (ordning == "stigande")
                    {
                        var sorteradeDagar = DagariMaj.OrderBy(dag => dag.Temp).ToList();

                        Console.WriteLine("Stigande ordning:");
                        foreach (var dag in sorteradeDagar)
                        {
                            Console.WriteLine($"{dag.Dagen}: {dag.Temp}°C");
                        }
                    }
                    else if (ordning == "fallande")
                    {
                        var sorteradeDagar = DagariMaj.OrderByDescending(dag => dag.Temp).ToList();

                        Console.WriteLine("Fallande ordning:");
                        foreach (var dag in sorteradeDagar)
                        {
                            Console.WriteLine($"{dag.Dagen}: {dag.Temp}°C");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fel val. Skriv 'stigande' eller 'fallande'.");
                    }

                    break;

                    

                case "g":
                    Console.WriteLine("Här är varma dagar då temperaturen är 20°C eller över.");

                    //Kontrollera om dagar har lika med eller över 20 grader >=20°C
                    bool finnsTemperaturOver20 = false;

                    foreach (var dag in DagariMaj)
                    {
                        if (dag.Temp >= 20) //Kontrollerar om temperaturen är över 20°C
                        {
                            Console.WriteLine($"{dag.Dagen} har temperaturen {dag.Temp}°C.");
                            finnsTemperaturOver20 = true;
                        }
                    }

                    if (!finnsTemperaturOver20) //om inga dagar har 20 eller över
                    {
                        Console.WriteLine("Ingen dag i maj har temperaturen 20°C eller över.");
                    }

                    break;



                case "h":
                    Console.WriteLine("Skriv in en dag i maj med siffra för att få den dagens temp samt temperaturen för dagen före och efter\n");
                    //[input -1 och +1] gör att vi skriver ut dagen inann och dagen efter
                    int input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{DagariMaj[input - 1].Dagen} har temperaturen {DagariMaj[input - 1].Temp}°C. ");
                    Console.WriteLine($"{DagariMaj[input].Dagen} har temperaturen {DagariMaj[input].Temp}°C. ");
                    Console.WriteLine($"{DagariMaj[input + 1].Dagen} har temperaturen {DagariMaj[input + 1].Temp}°C. ");

                    break;



                case "i":
                    //Visar den vanligast förekommande temperaturen i maj
                    Console.WriteLine("Här är den vanligast förekommande temperaturen i maj:");

                    var vanligasteTemperatur = DagariMaj

                    .GroupBy(dag => dag.Temp) //Grupperar temperaturerna
                    .OrderByDescending(grupp => grupp.Count()) //Sortera efter antal i fallande ordning
                    .First(); //Hämtar den mest förekommande temperaturen genom att räkna alla gånger den landar

                    //Resultatet
                    Console.WriteLine($"Den vanligast förekommande temperaturen är {vanligasteTemperatur.Key}°C och förekommer {vanligasteTemperatur.Count()} gånger.");

                    break;

            }
        }
    }
}