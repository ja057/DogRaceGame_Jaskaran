using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceGame_Jaskaran
{
    public class DogGreyHound: FuntionsInterface
    {
        public int DogStartingPosition; // where my PictureBox Starts
        public int TrackLength; //How long the racetrack is
        public PictureBox MyPictureBox = null; //My PictureBox object
        public Random Randomizer; //An integer random
        public int Loc = 0; //My Location on the track
        public bool DogRun()//This method is overridden by abstract class
        {
            Loc += Randomizer.Next(1, 5);
            MyPictureBox.Left = Loc;
            if (MyPictureBox.Left >= TrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DogStartPosition()//This method is overridden by abstract class
        {
            Loc = 0;
            MyPictureBox.Left = DogStartingPosition;
        }
    }
}
