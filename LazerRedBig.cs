using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    class LazerRedBig : Lazer
    {
        public override void CreateLazer(Form form)
        {
            CurrentLazer.Image = Properties.Resources.laserRed08;
            CurrentLazer.Tag = "enemyLazer";

            base.CreateLazer(form);
        }
    }
}
