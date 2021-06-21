using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceGame_Jaskaran
{
    public partial class DogRaceGame : Form
    {
        DogGreyHound[] dogStarts = new DogGreyHound[4]; // one array of 4 dog objects 
        DogPunter[] clientArray = new DogPunter[3]; // one array of 3 guy objects
        Random randNumbers = new Random();
        public DogRaceGame()
        {
            InitializeComponent();
            setRaceTrack();
        }

        private void setRaceTrack()//setting the race track
        {
            radioButtonJasbir.Checked = true;
            // initialize minimum bet label
            minimumBetLabel.Text = "Minimum Bet : " + numericUpDownForBet.Minimum.ToString() + " dollars";

            // initialize all 4 elements 
            dogStarts[0] = new DogGreyHound()
            {
                MyPictureBox = dog1,
                DogStartingPosition = dog1.Left,
                TrackLength = dogRaceTrack.Width - dog1.Width,
                Randomizer = randNumbers
            };

            dogStarts[1] = new DogGreyHound()
            {
                MyPictureBox = dog2,
                DogStartingPosition = dog2.Left,
                TrackLength = dogRaceTrack.Width - dog2.Width,
                Randomizer = randNumbers
            };

            dogStarts[2] = new DogGreyHound()
            {
                MyPictureBox = dog3,
                DogStartingPosition = dog3.Left,
                TrackLength = dogRaceTrack.Width - dog3.Width,
                Randomizer = randNumbers
            };

            dogStarts[3] = new DogGreyHound()
            {
                MyPictureBox = dog4,
                DogStartingPosition = dog4.Left,
                TrackLength = dogRaceTrack.Width - dog4.Width,
                Randomizer = randNumbers
            };

            //initialize all 3 elements 
            clientArray[0] = new DogPunter()
            {
                ClientName = "Jaskaran",
                dogBet = null,
                Cashes = 50,
                MyRadioButton = radioButtonJasbir,
                MyLabel = tejbirBetLabel
            };

            clientArray[1] = new DogPunter()
            {
                ClientName = "Rajinder",
                dogBet = null,
                Cashes = 50,
                MyRadioButton = radioButtonRajinder,
                MyLabel = rajinderBetLabel
            };

            clientArray[2] = new DogPunter()
            {
                ClientName = "Sandeep",
                dogBet = null,
                Cashes = 50,
                MyRadioButton = radioButtonSandeep,
                MyLabel = sandeepBetLabel
            };

            for (int i = 0; i <= 2; i++)
            {
                clientArray[i].UpdatingLabels();
                clientArray[i].dogBet = new DogBettor();
            }
        }

        private void raceBtn_Click(object sender, EventArgs e)
        {
            //dog take starting position
            dogStarts[0].DogStartPosition();
            dogStarts[1].DogStartPosition();
            dogStarts[2].DogStartPosition();
            dogStarts[3].DogStartPosition();

            //disable race button till the end of the race
            bettingParlor.Enabled = false;

            //start timer
            timer1.Start();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            foreach (DogGreyHound dg in dogStarts)
            {
                dg.DogStartPosition();
            }
            if (tejbirBetLabel.Text == "BUSTED" && rajinderBetLabel.Text == "BUSTED" && sandeepBetLabel.Text == "BUSTED")
            {
                setRaceTrack();

                clientArray[0] = new DogPunter()//punter class Initialization
                {
                    ClientName = "Tejbir",// name of client
                    dogBet = null,//Set the bet null
                    Cashes = 70,//set cash 70
                    MyRadioButton = radioButtonJasbir,//assign radio buuton
                    MyLabel = tejbirBetLabel//assign the labl to punter class
                };

                clientArray[1] = new DogPunter()
                {
                    ClientName = "Rajinder",
                    dogBet = null,
                    Cashes = 95,
                    MyRadioButton = radioButtonRajinder,
                    MyLabel = rajinderBetLabel
                };

                clientArray[2] = new DogPunter()
                {
                    ClientName = "Sandeep",
                    dogBet = null,
                    Cashes = 65,
                    MyRadioButton = radioButtonSandeep,
                    MyLabel = sandeepBetLabel
                };

                foreach (DogPunter punter in clientArray)
                {
                    punter.UpdatingLabels();
                }
                radioButtonJasbir.Enabled = true;
                radioButtonRajinder.Enabled = true;
                radioButtonSandeep.Enabled = true;
                numericUpDownForBet.Value = 1;
                numericUpDownNumber.Value = 1;

            }
        }

        private void betsBtn_Click(object sender, EventArgs e)
        {
            if (radioButtonJasbir.Checked)
            {
                if (clientArray[0].PlaceBet((int)numericUpDownForBet.Value, (int)numericUpDownNumber.Value))
                {
                    tejbirBetLabel.Text = clientArray[0].dogBet.GetTheDescription();
                }
            }
            else if (radioButtonRajinder.Checked)
            {
                if (clientArray[1].PlaceBet((int)numericUpDownForBet.Value, (int)numericUpDownNumber.Value))
                {
                    rajinderBetLabel.Text = clientArray[1].dogBet.GetTheDescription();
                }
            }
            else if (radioButtonSandeep.Checked)
            {
                if (clientArray[2].PlaceBet((int)numericUpDownForBet.Value, (int)numericUpDownNumber.Value))
                {
                    sandeepBetLabel.Text = clientArray[2].dogBet.GetTheDescription();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (dogStarts[i].DogRun())
                {
                    timer1.Stop();
                    bettingParlor.Enabled = true;
                    i++;
                    MessageBox.Show("Dog " + i + " won the race");
                    for (int j = 0; j <= 2; j++)
                    {
                        clientArray[j].Collect(i);
                        clientArray[j].ClearTheBet();
                    }

                    foreach (DogGreyHound dg in dogStarts)
                    {
                        dg.DogStartPosition();
                    }
                    break;
                }
            }
        }
    }
}
