using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SpaceShooter
{
    public class SpawnManager
    {
        SpaceShooter gameScreen;

        Random randomSpawn = new Random();

        Timer spawnTimer = new Timer();

        Pill pill;

        bool isPill = false;

        public bool IsPill { get => isPill; set => isPill = value; }

        public SpawnManager(SpaceShooter game)
        {
            gameScreen = game;

            spawnTimer.Interval = 1000;
            spawnTimer.Tick += new EventHandler(SpawnTick);
            spawnTimer.Start();
        }

        private void SpawnTick(object sender, EventArgs e)
        {
            if (randomSpawn.Next(0, 1000) < 500)
            {
                if (!IsPill)
                {
                    SpawnPill();
                }
            }
            if (randomSpawn.Next(0, 20000) < 300)
            {
                SpawnYellowUFO();
            }
            if (randomSpawn.Next(0, 20000) < 300)
            {
                SpawnRedUFO();
            }
        }

        private void SpawnYellowUFO()
        {
            Ufo ufo = new UfoYellow();
            ufo.SpawnUFO(gameScreen);
        }
        private void SpawnRedUFO()
        {
            Ufo ufo = new UfoRed();
            ufo.SpawnUFO(gameScreen);
        }
        private void SpawnPill()
        {
            pill = new Pill();

            pill.PillPosLeft = randomSpawn.Next(20, gameScreen.ClientSize.Width - pill.PillSpawn.Width);

            pill.PillPosTop = randomSpawn.Next(20, gameScreen.ClientSize.Height - pill.PillSpawn.Height);

            pill.SpawnPill(gameScreen);

            IsPill = true;
        }
    }
}
