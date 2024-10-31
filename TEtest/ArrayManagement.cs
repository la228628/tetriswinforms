using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEtest
{
    public static class ArrayManagement
    {
        public static bool ContainsCoordinates<Type>(this Type[,] Tableau, int Ligne, int Colonne)
        {
            if (Ligne < 0 || Ligne >= Tableau.GetLength(0))
            {
                return false;
            }
            if (Colonne < 0 || Colonne >= Tableau.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
