    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogRaceGame_Jaskaran
{
    public class DogBettor
    {
        public int Amounts; // amount variable
        public int dog; //dog variable
        public DogPunter Punter; //punter variable

        public string GetTheDescription()
        {
            string description = "";
            description = this.Punter.ClientName + " bets " + Amounts + " dollars on Dog #" + dog;
            return description;
        }

        public int PayOut(int winner)
        {
            if (dog == winner)
            {
                return Amounts;
            }
            else
            {
                return -Amounts;
            }
        }
    }
}
