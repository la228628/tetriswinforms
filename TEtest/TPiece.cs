using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    internal class TPiece : Piece
    {
        public TPiece()
        {
            this.BasePointsArray = new[] { (3, 0), (4, 0), (5, 0), (4, 1) };
            this.PieceColor = Color.Purple;

            this.CurrentPositions = this.BasePointsArray;

        }


        public override (int, int)[] PositionsAfterRotations(int formIncrement)
        {

            (int, int)[] newArrayCases = new (int, int)[this.CurrentPositions.Length];

            switch (formIncrement)
            {
                case 0:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 + 1, this.CurrentPositions[0].Item2 + 1);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1, this.CurrentPositions[1].Item2);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1 - 1, this.CurrentPositions[2].Item2 - 1);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 + 1, this.CurrentPositions[3].Item2 - 1);
                    break;
                case 1:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 + 1, this.CurrentPositions[0].Item2 - 1);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1, this.CurrentPositions[1].Item2);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1 - 1, this.CurrentPositions[2].Item2 + 1);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 - 1, this.CurrentPositions[3].Item2 - 1);
                    break;
                case 2:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 - 1, this.CurrentPositions[0].Item2 - 1);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1, this.CurrentPositions[1].Item2);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1 + 1, this.CurrentPositions[2].Item2 + 1);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 - 1, this.CurrentPositions[3].Item2 + 1);
                    break;
                case 3:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1 - 1, CurrentPositions[0].Item2 + 1);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1, CurrentPositions[1].Item2);
                    newArrayCases[2] = (CurrentPositions[2].Item1 + 1, CurrentPositions[2].Item2 - 1);
                    newArrayCases[3] = (CurrentPositions[3].Item1 + 1, CurrentPositions[3].Item2 + 1);
                    break;

            }
            return newArrayCases;
        }
    }
}
