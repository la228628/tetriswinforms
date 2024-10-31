using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    public class JPiece : Piece
    {
        public JPiece()
        {
            this.BasePointsArray = new[] { (3, 0), (3, 1), (3, 2), (3, 3), (2, 3) };
            this.PieceColor = Color.DarkBlue;

            this.CurrentPositions = this.BasePointsArray;


        }

        public override (int, int)[] PositionsAfterRotations(int formIncrement)
        {
            (int, int)[] newArrayCases = new (int, int)[this.CurrentPositions.Length];

            switch (formIncrement)
            {
                case 0:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 - 2, this.CurrentPositions[0].Item2 + 2);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1 - 1, this.CurrentPositions[1].Item2 + 1);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1, this.CurrentPositions[2].Item2);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 + 1, this.CurrentPositions[3].Item2 - 1);
                    newArrayCases[4] = (this.CurrentPositions[4].Item1+2, this.CurrentPositions[4].Item2);
                    break;
                case 1:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 + 2, this.CurrentPositions[0].Item2 + 2);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1 + 1, this.CurrentPositions[1].Item2 + 1);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1, this.CurrentPositions[2].Item2);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 - 1, this.CurrentPositions[3].Item2 - 1);
                    newArrayCases[4] = (this.CurrentPositions[4].Item1 , this.CurrentPositions[4].Item2-2);
                    break;
                case 2:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 + 2, this.CurrentPositions[0].Item2 - 2);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1 + 1, this.CurrentPositions[1].Item2 - 1);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1, this.CurrentPositions[2].Item2);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 - 1, this.CurrentPositions[3].Item2 + 1);
                    newArrayCases[4] = (this.CurrentPositions[4].Item1-2, this.CurrentPositions[4].Item2);
                    break;
                case 3:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 - 2, this.CurrentPositions[0].Item2 - 2);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1 - 1, this.CurrentPositions[1].Item2 - 1);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1, this.CurrentPositions[2].Item2);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 + 1, this.CurrentPositions[3].Item2 + 1);
                    newArrayCases[4] = (this.CurrentPositions[4].Item1, this.CurrentPositions[4].Item2+2);
                    break;

            }
            return newArrayCases;
        }




    }
}
