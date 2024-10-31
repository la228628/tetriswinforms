using System.Diagnostics;

namespace TEtest
{
    public partial class GameForm : Form
    {

        private Game CurrentGame;

        private Label[,] LabelCaseBox;
        private Label[,] NextPieceBox;

        private int LabelBoxX;
        private int LabelBoxY;

        private int YDistanceFromTop = 75;
        private int LabelSize = 40;

        private System.Windows.Forms.Timer FormTimer;
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public string Song;

        public GameForm(string song)
        {
            InitializeComponent();
            this.CurrentGame = new Game();

            this.LabelBoxX = this.CurrentGame.CaseBox.GetLength(0);
            this.LabelBoxY = this.CurrentGame.CaseBox.GetLength(1);

            Debug.WriteLine(LabelBoxX + "and " + LabelBoxY);

            this.LabelCaseBox = new Label[this.LabelBoxX, this.LabelBoxY];
            this.NextPieceBox = new Label[5, 5];
            this.Song = song;
            this.player.SoundLocation = this.Song;


            InitCaseBox();
            InitNextPieceCaseBox(this.LabelBoxX * this.LabelSize + 15);
            FillNextPieceCaseBox();

            this.FormTimer = new System.Windows.Forms.Timer();


            this.FormTimer.Tick += new EventHandler(UpdateLabelBox);

            this.KeyPreview = true;

            this.WindowState = FormWindowState.Maximized;

        }


        public void InitCaseBox()
        {


            for (int x = 0; x < LabelBoxX; x++)
            {
                for (int y = 0; y < LabelBoxY; y++)
                {
                    initLabel(x, y);
                }
            }
        }

        private void InitNextPieceCaseBox(int distance)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label labelNextCase = new Label();
                    labelNextCase.Location = new Point(distance + i * this.LabelSize, this.YDistanceFromTop+j * this.LabelSize);
                    labelNextCase.Size = new Size(this.LabelSize, this.LabelSize);
                    labelNextCase.BackColor = Color.White;
                    labelNextCase.BorderStyle = BorderStyle.FixedSingle;
                    labelNextCase.ForeColor = Color.Black;
                    this.NextPieceBox[i, j] = labelNextCase;
                    this.Controls.Add(labelNextCase);
                }
            }
        }

        private void FillNextPieceCaseBox()
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    NextPieceBox[j, k].BackColor = Color.White;
                }
            }
            Color color = CurrentGame.NextPiece.PieceColor;
            for (int i = 0; i < CurrentGame.NextPiece.BasePointsArray.Length; i++)
            {
                NextPieceBox[CurrentGame.NextPiece.BasePointsArray[i].Item1 - 2, CurrentGame.NextPiece.BasePointsArray[i].Item2].BackColor = color;
            }
        }

        private void initLabel(int l, int c)
        {

            Label labelCase = new Label();
            labelCase.Location = new Point(l * this.LabelSize, this.YDistanceFromTop + c * this.LabelSize);
            labelCase.Size = new Size(this.LabelSize, this.LabelSize);
            labelCase.BackColor = this.CurrentGame.CaseBox[l, c].Color;
            labelCase.BorderStyle = BorderStyle.FixedSingle;
            labelCase.ForeColor = Color.Black;
            this.LabelCaseBox[l, c] = labelCase;

            this.Controls.Add(labelCase);
        }


        private void UpdateLabelBox(object sender, EventArgs e)
        {
            if (this.CurrentGame.GameOver)
            {
                this.Close();
                this.player = new System.Media.SoundPlayer();
            }
            for (int i = 0; i < this.LabelBoxX; i++)
            {
                for (int j = 0; j < this.LabelBoxY; j++)
                {
                    this.LabelCaseBox[i, j].BackColor = this.CurrentGame.CaseBox[i, j].Color;
                }
            }




            FillNextPieceCaseBox();

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentGame.GameTimer.IsRunning == false)
            {
                this.CurrentGame.BeginTimer();
                this.FormTimer.Start();
                this.player.PlayLooping();
                Debug.WriteLine("Timers lancés");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            char input = 'n';
            switch (e.KeyCode)
            {
                case Keys.Q:
                    input = 'l';
                    break;
                case Keys.D:
                    input = 'r';
                    break;
                case Keys.Z:
                    input = 'u';
                    break;
                case Keys.S:
                    input = 'd';
                    break;
                default:
                    break;


            }
            this.CurrentGame.HandleKeyPress(input);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}