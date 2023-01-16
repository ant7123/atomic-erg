using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public abstract class Ufo
    {
        PictureBox ufo;

        int ufoPosLeft;
        int ufoPosTop;

        public PictureBox UFOSpawn { get => ufo; set => ufo = value; }
        public int UfoPosLeft { get => ufoPosLeft; set => ufoPosLeft = value; }
        public int UfoPosTop { get => ufoPosTop; set => ufoPosTop = value; }

        public virtual void SpawnUFO(Form form)
        {
            ufo = new PictureBox();
            UFOSpawn.Tag = "ufo";
            UFOSpawn.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
