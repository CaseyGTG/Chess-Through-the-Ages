using Assets.Code.ChessData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ChessData.Pieces.MovementData
{
    public class ChessPieceMovementDefinition
    {
        public ChessPieceMovementDefinition(ChessMovementType movementType, List<UserDefinedMovement>? userDefinedMovements = null)
        {
            MovementType = movementType;

            if(MovementType == ChessMovementType.UserDefined)
            {
                UserDefinedMovements = userDefinedMovements;
            }
        }

        public ChessMovementType MovementType;

        public List<UserDefinedMovement>? UserDefinedMovements;
    }
}
