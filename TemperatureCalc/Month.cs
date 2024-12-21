namespace TemperatureCalc
{
    internal class Month
    {
        //Public egenskaper för att hämta dagar och temperaturer
        public string Dagen {   get; private set; } 
        public int Temp { get; private set; } 

        public Month(string a) //Public metod med Konstruktor som har en parameter
        {
            Dagen = a; // Sätt dagens namn
            Temp = Random_temp(); // Genererar random temperaturer

        }

        private int Random_temp() //Privat metod som returnerar en int, genererar slumpmässiga temperaturer mellan 15 till 25, inte 26
        {
            //objekt av klassen Random
            Random random = new Random();
            int Rand_Temp = random.Next(15, 26);

            return Rand_Temp; //Returnerar de slumpmässigt genererade temperaturerna

        }
    }
}