using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class PlayerStats : Form
    {
        public PlayerStats()
        {
            InitializeComponent();
        }

        private void PlayerStats_Load(object sender, EventArgs e)
        {
            RuleCards Rules = new RuleCards();
            Rules.Location = new Point(0,0);
            //Rules Image
            Rules.Image = Properties.Resources.Rules_image;
            Bitmap bmp = new Bitmap(picBox1.Width, picBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(Rules.Image, Rules.Location.X, Rules.Location.Y, Rules.SizeY, Rules.SizeX);

            }
            picBox1.Image = bmp;
        }

        private void CmdMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new MMenu();
            Menu.Show();
        }
    }
}
