using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    class UfoRed : Ufo
    {
        Lazer lazerLeft;

        Timer shootTimer = new Timer();

        Form gameScreen;

        Random random = new Random();


        public override void SpawnUFO(Form form)
        {
            base.SpawnUFO(form);

            UFOSpawn.Left = random.Next(1000, 1200);
            UFOSpawn.Top = random.Next(200, 600);
            gameScreen = form;
            UFOSpawn.Image = Properties.Resources.UFORED;
            gameScreen.Controls.Add(UFOSpawn);
            UFOSpawn.BringToFront();

            shootTimer.Interval = 1200;
            shootTimer.Tick += new EventHandler(ShootTick);
            shootTimer.Start();
        }

        private void ShootTick(object sender, EventArgs e)
        {
            if (!gameScreen.Controls.Contains(UFOSpawn))
            {
                lazerLeft = null;
                shootTimer.Stop();
            }
            else
            {
              
                lazerLeft = new LazerRedBig();

                lazerLeft.Direction = Direction.left;
                lazerLeft.LazerPosLeft = UFOSpawn.Left + (UFOSpawn.Width / 2);
                lazerLeft.LazerPosTop = UFOSpawn.Top + (UFOSpawn.Height / 2);
                lazerLeft.CreateLazer(gameScreen);
            }
        }
    }
}
