using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEtest
{
    public partial class MenuForm : Form
    {
        private string SongChoice;


        public GameForm game;
        public MenuForm()
        {
            this.SongChoice = "TetrisSongWav.wav";

            game = new GameForm(this.SongChoice);
            InitializeComponent();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("formClosed");
            this.game.player.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            this.game = new GameForm(this.SongChoice);
            this.game.FormClosed += pictureBox1_Click;
            this.game.ShowDialog();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.SongChoice = "Tetris.wav";
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.SongChoice = "Tetris2012.wav";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.SongChoice = "TetrisSongWav.wav";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
