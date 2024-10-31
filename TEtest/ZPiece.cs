using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    public class ZPiece : Piece
    {
        public ZPiece() {
            this.BasePointsArray = new[] { (3, 0), (4, 0), (4, 1), (5, 1) };
            this.PieceColor = Color.Red;

            this.CurrentPositions = this.BasePointsArray;


        }

        public override (int, int)[] PositionsAfterRotations(int formIncrement)
        {
            (int,int)[] newArrayCases = new (int, int)[this.CurrentPositions.Length];

            switch (formIncrement)
            {
                case 0:
                case 2:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1, this.CurrentPositions[0].Item2 + 2);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1 - 1, this.CurrentPositions[1].Item2 + 1);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1, this.CurrentPositions[2].Item2);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 - 1, this.CurrentPositions[3].Item2 - 1);
                    break;
                case 1:
                case 3:
                    newArrayCases[0] = (this.CurrentPositions[0].Item1, this.CurrentPositions[0].Item2 - 2);
                    newArrayCases[1] = (this.CurrentPositions[1].Item1 + 1, this.CurrentPositions[1].Item2 - 1);
                    newArrayCases[2] = (this.CurrentPositions[2].Item1, this.CurrentPositions[2].Item2);
                    newArrayCases[3] = (this.CurrentPositions[3].Item1 + 1, this.CurrentPositions[3].Item2 + 1);
                    break;


            }
            return newArrayCases;
        }

    }
}
