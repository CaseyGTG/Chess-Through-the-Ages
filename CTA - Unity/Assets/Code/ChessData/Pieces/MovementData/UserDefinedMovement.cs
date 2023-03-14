using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ChessData.Pieces.MovementData
{
    public class UserDefinedMovement
    {
        public UserDefinedMovement(int vertically, int horizontally)
        {
            Vertically = vertically;
            Horizontally = horizontally;
        }

        public int Vertically { get; set; }

        public int Horizontally { get; set; }
    }
}
