using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SpaceShooter
{
    class UfoYellow : Ufo
    {
        Lazer lazerUp;
        Lazer lazerDown;
        Lazer lazerLeft;
        Lazer lazerRight;

        Timer shootTimer = new Timer();

        Form gameScreen;

        Random randomNum = new Random();

        public override void SpawnUFO(Form form)
        {
            base.SpawnUFO(form);

            UFOSpawn.Left = randomNum.Next(-200, 1200);
            UFOSpawn.Top = randomNum.Next(-100,0);
            gameScreen = form;
            UFOSpawn.Image = Properties.Resources.UFOYELLOW;
            gameScreen.Controls.Add(UFOSpawn);
            UFOSpawn.BringToFront();

            shootTimer.Interval = 1000;
            shootTimer.Tick += new EventHandler(ShootTick); 
            shootTimer.Start();
        }
        private void ShootTick(object sender,EventArgs e)
        {
            if (!gameScreen.Controls.Contains(UFOSpawn))
            {
                lazerUp = null;
                lazerDown = null;
                lazerLeft = null;
                lazerRight = null;
                shootTimer.Stop();
            }
            else
            {
                lazerUp = new LazerRed();
                lazerDown = new LazerRed();
                lazerLeft = new LazerRed();
                lazerRight = new LazerRed();

                lazerUp.Direction = Direction.up;
                lazerUp.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerUp.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerUp.CreateLazer(gameScreen);

                lazerDown.Direction = Direction.down;
                lazerDown.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerDown.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerDown.CreateLazer(gameScreen);

                lazerLeft.Direction = Direction.left;
                lazerLeft.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerLeft.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerLeft.CreateLazer(gameScreen);

                lazerRight.Direction = Direction.right;
                lazerRight.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerRight.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerRight.CreateLazer(gameScreen);
            }
        }
       
    }
}
