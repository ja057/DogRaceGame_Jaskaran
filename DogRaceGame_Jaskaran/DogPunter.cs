using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceGame_Jaskaran
{
    public class DogPunter
    {
        public string ClientName; //the client's name
        public DogBettor dogBet; //an istance of Bet that has his bet
        public int Cashes; //how much cash he has
        //punter's control on the form
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdatingLabels()
        {
            MyRadioButton.Text = ClientName + " has " + Cashes + " quids";
            MyLabel.Text = ClientName + " hasn't place a bet";

            if (Cashes == 0)//When bettor has no money to bet then it gets finish
            {
                MyLabel.Text = String.Format("BUSTED");
                MyLabel.ForeColor = System.Drawing.Color.Red;
                MyRadioButton.Enabled = false;
            }

        }

        public void ClearTheBet()
        {
            dogBet.Amounts = 0;//initialize amount
            dogBet.dog = 0;//initialize dog
            dogBet.Punter = this;
        }

        public bool PlaceBet(int BetAmount, int dogToWin)
        {
            if (Cashes >= BetAmount)
            {
                dogBet.Amounts = BetAmount;//initialize amount
                dogBet.dog = dogToWin;//initialize dog
                dogBet.Punter = this;
                return true;
            }
            else return false;
        }

        public void Collect(int winner)
        {
            Cashes += dogBet.PayOut(winner);
            this.UpdatingLabels();
        }
    }
}
