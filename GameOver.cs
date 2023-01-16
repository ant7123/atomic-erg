﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class GameOver : Form
    {
        int finalScore;

        public GameOver(int score)
        {
            InitializeComponent();
            finalScore = score;
        }


        private void BtnMainMenu(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            labelScore.Text = "Final Score :" + finalScore;
        }
    }
}
