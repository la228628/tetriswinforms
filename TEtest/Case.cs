using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    public class Case
    {
        public Color Color;
        public char State;
        public (int, int) Coordinate;

        public Case((int, int) coordinate)
        {

            this.Color = Color.White;
            this.State = 'E';
            this.Coordinate = coordinate;
        }
    }
}
