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
    public partial class MMenu : Form
    {
        public MMenu()
        {
            InitializeComponent();
        }

        private void CmdStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Rummy = new Rummy();
            Rummy.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Rules = new PlayerStats();
            Rules.Show();
        }
    }
}
