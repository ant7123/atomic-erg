﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    class LazerRed : Lazer
    {

        public override void CreateLazer(Form form)
        {
            if (Direction == Direction.left)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_Red_Left;
            }
            if (Direction == Direction.right)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_Red_Right;
            }
            if (Direction == Direction.up)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_Red_Up;

            }
            if (Direction == Direction.down)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_Red_Down;
            }

            CurrentLazer.Tag = "enemyLazer";

            base.CreateLazer(form);
        }
    }
}
