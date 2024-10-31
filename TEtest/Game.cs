using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TEtest
{
    public class Game
    {
        public Case[,] CaseBox;
        public Piece CurrentPiece;
        public Piece NextPiece;

        public Stopwatch GameTimer;

        private Stopwatch CoolDownTimer;
        public bool GameOver;




        public Game()
        {
            this.GameOver = false;
            this.CaseBox = new Case[10, 20];
            this.CurrentPiece = ChooseRandomPiece();
            this.NextPiece = ChooseRandomPiece();

            //this.CurrentPiece = new IPiece();
            //this.NextPiece = new IPiece();


            this.GameTimer = new Stopwatch();
            this.CoolDownTimer = new Stopwatch();
            InitCases();
            InitMovingCases();

        }


        private Piece ChooseRandomPiece()
        {
            Piece PieceChoice = new TPiece();
            Random random = new Random();
            switch (random.Next(0, 7))
            {
                case 0:
                    PieceChoice = new TPiece();
                    break;
                case 1:
                    PieceChoice = new LPiece();
                    break;
                case 2:
                    PieceChoice = new IPiece();
                    break;
                case 3:
                    PieceChoice = new ZPiece();
                    break;
                case 4:
                    PieceChoice = new OPiece();
                    break;
                case 5:
                    PieceChoice = new SPiece();
                    break;
                case 6:
                    PieceChoice = new JPiece();
                    break;
            }

            return PieceChoice;
        }


        private void InitCases()
        {
            for (int i = 0; i < this.CaseBox.GetLength(0); i++)
            {
                for (int j = 0; j < this.CaseBox.GetLength(1); j++)
                {
                    this.CaseBox[i, j] = new Case((i, j));
                }
            }
        }

        private void InitMovingCases()
        {
            for (int i = 0; i < this.CaseBox.GetLength(0); i++)
            {
                for (int j = 0; j < this.CaseBox.GetLength(1); j++)
                {
                    if (CurrentPiece.BasePointsArray.Contains((i, j)))
                    {
                        this.CaseBox[i, j].State = 'M';

                        this.CaseBox[i, j].Color = CurrentPiece.PieceColor;
                    }
                }
            }
        }


        private void ManageMoveYPieces()
        {
            while (GameOver == false)
            {
                this.CurrentPiece.MovePieceY(this.CaseBox);
                
                this.UpdateCaseBox();
                if (this.CurrentPiece.IsMovableY(this.CaseBox) == false)
                {
                    if (this.CoolDownTimer.IsRunning == false)
                    {
                        this.CoolDownTimer.Start();
                    }
                    else if (this.CoolDownTimer.ElapsedMilliseconds > 500)
                    {
                   
                        this.CoolDownTimer.Stop();
                        ChangePiece();

                    }
                    ClearFilledRows();
                }


                Thread.Sleep(250);

            }

            if (this.GameOver)
            {
                Debug.WriteLine("GameOver");
                this.GameTimer.Restart();
                this.GameTimer.Stop();
            }
        }

        private void UpdateCaseBox()
        {
            foreach (Case aCase in this.CaseBox)
            {
                if (aCase.State != 'S')
                {
                    aCase.State = 'E';
                    aCase.Color = Color.White;
                }
            }
            foreach (Case bCase in this.CaseBox)
            {
                foreach ((int, int) position in this.CurrentPiece.CurrentPositions)
                {
                    if (bCase.Coordinate == position)
                    {
                        bCase.State = 'M';
                        bCase.Color = CurrentPiece.PieceColor;
                    }
                }
            }
        }


        private void ChangePiece()
        {
            foreach (Case aCase in this.CaseBox)
            {
                if (aCase.State != 'E')
                {
                    aCase.State = 'S';
                }
            }
            if (NextPiece.IsPlacable(this.CaseBox, NextPiece.BasePointsArray))
            {
            this.CurrentPiece = this.NextPiece;
                this.NextPiece = ChooseRandomPiece();
                //this.NextPiece = new IPiece();
            InitMovingCases();
            }
            else
            {
                this.GameOver = true;
            }

        }



        public void HandleKeyPress(char direction)
        {
            if (this.GameTimer.IsRunning)
            {
                switch (direction)
                {
                    case 'r':
                        this.CurrentPiece.MovePieceX(1, this.CaseBox);
                        break;
                    case 'l':
                        this.CurrentPiece.MovePieceX(-1, this.CaseBox);
                        break;
                    case 'u':
                        this.CurrentPiece.SwitchForm(this.CaseBox);
                        break;
                    case 'd':
                        this.CurrentPiece.FallDown(this.CaseBox);
                        break;
                }

                this.UpdateCaseBox();
            }
        }



        private List<int> FilledRowsList()
        {
            List<int> rows = new List<int>();

            
            for(int y  = 0; y < this.CaseBox.GetLength(1); y++)
            {
                int increment = 0;
                for(int x = 0;x<  this.CaseBox.GetLength(0);x++ )
                {
                    if (this.CaseBox[x,y].State == 'S' && this.CaseBox[x,y].Color !=Color.White)
                    {
                        increment++;
                    }
                }
                if(increment == this.CaseBox.GetLength(0))
                {
                    Debug.Close();
                    rows.Add(y);
                    Debug.WriteLine(y + "filled");


                }
            }

            return rows;
        }

        private void ClearFilledRows()
        {
            List<int> rowsToClear = FilledRowsList();
            if(rowsToClear.Count > 0 )
            {

                foreach (int row in rowsToClear)
                {
                    foreach(Case aCase in this.CaseBox)
                    {
                        if(aCase.Coordinate.Item2 == row)
                        {
                            
                            aCase.State = 'E';
                            aCase.Color = Color.White;
                        }
                    }
                }
                Debug.WriteLine("{0} lignes de descente ", rowsToClear.Count());
                FallAllCases(rowsToClear.Count(), rowsToClear.Min());
            }
        }

        



        private void FallAllCases(int number,int index)
        {
            Case[,] newCaseBox = new Case[this.CaseBox.GetLength(0), this.CaseBox.GetLength(1)];

            for (int i = 0; i < newCaseBox.GetLength(0); i++)
            {
                for (int j = 0; j < newCaseBox.GetLength(1); j++)
                {
                    newCaseBox[i, j] = new Case((i, j));
                }
            }
            for (int x = 0; x < newCaseBox.GetLength(0); x++)
            {
                for (int y = 0; y < newCaseBox.GetLength(1); y++)
                {

                    if (newCaseBox.ContainsCoordinates(x, y + number) && this.CaseBox[x, y].State == 'S' && y < index)
                    {
                        newCaseBox[x, y + number].State = this.CaseBox[x, y].State;
                        newCaseBox[x, y + number].Color = this.CaseBox[x, y].Color;
                    }
                    else if (y >= index && this.CaseBox[x, y].State == 'S')
                    {
                        newCaseBox[x, y].State = this.CaseBox[x, y].State;
                        newCaseBox[x, y].Color = this.CaseBox[x, y].Color;
                    }
                }
            }









            this.CaseBox = newCaseBox;
        }

        private Case[,] createNewCaseBox()
        {
            Case[,] newCaseBox = new Case[this.CaseBox.GetLength(0), this.CaseBox.GetLength(1)];
            for (int i = 0; i < newCaseBox.GetLength(0); i++)
            {
                for (int j = 0; j < newCaseBox.GetLength(1); j++)
                {
                    newCaseBox[i, j] = new Case((i, j));
                }
            }
            return newCaseBox;
        }


        public void BeginTimer()
        {
            this.GameTimer.Start();
            Debug.WriteLine("jeu lancé");
            Task.Run(ManageMoveYPieces);
        }
    }

}