using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class SpaceShooter : Form
    {

        SpawnManager spawnManage;
        CollisionManager collisionManage;
        EnemyMovement movementManage;

        bool goLeft, goRight, goUp, goDown;

        int playerShield = 100;

        int speed = 10;

        int score = 0;

        Direction playerDirection;

        public SpawnManager SpawnManage { get => SpawnManage;}
        public int PlayerShield { get => playerShield; set => playerShield = value;}
        public int Score { get => score; set => score = value;}


        public SpaceShooter()
        {
            spawnManage = new SpawnManager(this);
            collisionManage = new CollisionManager(this);
            movementManage = new EnemyMovement(this);
            InitializeComponent();
        }

        private void GameTick(object sender, EventArgs e)
        {
            player.BringToFront();

            IsPlayerAlive();

            labelScore.Text = "Score:" + Score;

            MovePlayer();

            collisionManage.DetectCollision();

            movementManage.MoveUFO();
        }

        private void MovePlayer()
        {
            if(goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }

            if(goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 0)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height - 100)
            {
                player.Top += speed;
            }
        }

        private void IsPlayerAlive()
        {
            if (PlayerShield > 1)
            {
                shieldsBar.Value = PlayerShield;
            }
            else
            {
                gameTimer.Stop();

                GameOver gameOver = new GameOver(score);
                gameOver.ShowDialog();
                this.Close();
            }
        }

        private void SpaceShooter_Load(object sender, EventArgs e)
        {

        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                playerDirection = Direction.left;
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                playerDirection = Direction.right;
                player.Image = Properties.Resources.Right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                playerDirection = Direction.up;
                player.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                playerDirection = Direction.down;
                player.Image = Properties.Resources.down;
            }
        }

        private void IsKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                ShootLazer(playerDirection);
            }
        }

        private void ShootLazer(Direction direction)
        {
            Lazer newLazer = new LazerBlue();
            newLazer.Direction = playerDirection;
            newLazer.LazerPosLeft = player.Left + (player.Width /2);
            newLazer.LazerPosTop = player.Top + (player.Height / 2);
            newLazer.CreateLazer(this);
        }
    }
}
