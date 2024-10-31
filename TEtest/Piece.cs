using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    public abstract class Piece
    {
        
        public (int,int)[] BasePointsArray;

        public Color PieceColor;


        public (int, int)[] CurrentPositions;

        private int FormIncrement;

        


        public Piece ()
        {
            this.FormIncrement = 0;
        }

        public bool IsMovableY(Case[,] CaseBox )
        {
            for (int i = 0; i < this.CurrentPositions.Length; i++)
            {
                if (!CaseBox.ContainsCoordinates(this.CurrentPositions[i].Item1, this.CurrentPositions[i].Item2 + 1) || CaseBox[this.CurrentPositions[i].Item1, this.CurrentPositions[i].Item2 + 1].State == 'S')
                {
                    return false;
                }
            }
            return true;

        }

        public bool IsMovableX(int direction, Case[,] CaseBox)
        {
            for (int i = 0; i < this.CurrentPositions.Length; i++)
            {
                if (!CaseBox.ContainsCoordinates(this.CurrentPositions[i].Item1 + direction, this.CurrentPositions[i].Item2) || CaseBox[this.CurrentPositions[i].Item1 + direction, this.CurrentPositions[i].Item2].State == 'S')
                {
                    return false;
                }
            }
            return true;
        }


        public bool OkayForRotate(Case[,] CaseBox, (int, int)[] newPositions)
        {
            foreach (var position in newPositions)
            {
                if (!CaseBox.ContainsCoordinates(position.Item1, position.Item2))
                {
                    return false;
                }
                else if (CaseBox[position.Item1, position.Item2].State == 'S')
                {
                    return false;
                }
            }
            return true;
        }

        public virtual (int, int)[] PositionsAfterRotations(int formIncrement)
        {
            return this.CurrentPositions;
        }


        public void SwitchForm(Case[,] CaseBox)
        {
            (int, int)[] newArrayCases = this.PositionsAfterRotations(this.FormIncrement);
            if (this.OkayForRotate(CaseBox,newArrayCases) && this.IsMovableY(CaseBox))
            {

                this.CurrentPositions = newArrayCases;



                if (this.FormIncrement == 3)
                {
                    this.FormIncrement = 0;
                }
                else
                {
                    this.FormIncrement++;
                }
            }
        }



        public void MovePieceY(Case[,] CaseBox)
        {

            if (this.IsMovableY(CaseBox))
            {
                for (int i = 0; i < this.CurrentPositions.Length; i++)
                {
                    this.CurrentPositions[i] = (this.CurrentPositions[i].Item1, this.CurrentPositions[i].Item2 + 1);
                }

            }
        }


        public void FallDown(Case[,] CaseBox)
        {
            while(this.IsMovableY(CaseBox) == true)
            {
                this.MovePieceY(CaseBox);
            }
        }



        public void MovePieceX(int direction, Case[,] CaseBox)
        {
            if (this.IsMovableX(direction, CaseBox))
            {
                for (int i = 0; i < this.CurrentPositions.Length; i++)
                {
                    this.CurrentPositions[i] = (this.CurrentPositions[i].Item1 + direction, this.CurrentPositions[i].Item2);
                }
            }
        }

        
        public bool IsPlacable(Case[,] CaseBox, (int, int)[] basePositions )
        {
            foreach ((int,int) position in basePositions)
            {
                if(CaseBox[position.Item1, position.Item2].State== 'S')
                {
                    return false;
                }
            }
            return true;
        }



        


    }
}
