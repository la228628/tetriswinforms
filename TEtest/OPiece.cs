using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    public class OPiece : Piece
    {
        public OPiece() 
        {
            this.BasePointsArray = new[] { (3, 0), (3, 1), (4, 0), (4, 1) };
            this.PieceColor = Color.Yellow;

            this.CurrentPositions = this.BasePointsArray;

        }
    }
}
