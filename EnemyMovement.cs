using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooter
{
    public class EnemyMovement
    {
        SpaceShooter gameScreen;

        Timer gameTime = new Timer();

        int speed= 1;

        public EnemyMovement(SpaceShooter game)
        {
            gameScreen = game;

            gameTime.Interval = 20000;
            gameTime.Start();
            gameTime.Tick += new EventHandler(GameTick);
        }
        public void MoveUFO()
        {

            foreach (Control x in gameScreen.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ufo")
                {
                    if (x.Left > gameScreen.player.Left)
                    {
                        x.Left -= speed;
                    }
                    if (x.Left < gameScreen.player.Left)
                    {
                        x.Left += speed;
                    }
                    if (x.Top > gameScreen.player.Top)
                    {
                        x.Top -= speed;
                    }
                    if (x.Top < gameScreen.player.Top)
                    {
                        x.Top += speed;
                    }
                }
            }
        }
        public void GameTick(object sender, EventArgs e)
        {
            speed++;
        }
    }
}
