using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureCalc
{
    internal class Month
    {

        public string Dagen { get; private set; }
        public int Temp { get; private set; }

        public Month(string a)
        {
            Dagen = a;
            Temp = Random_temp();

        }

        private int Random_temp()
        {
            Random random = new Random();
            int Rand_Temp = random.Next(15, 26);

            return Rand_Temp;

        }
    }
}