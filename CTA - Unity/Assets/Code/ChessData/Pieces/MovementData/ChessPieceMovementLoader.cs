using Assets.Code.ChessData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Code.ChessData.Pieces.MovementData
{
    public static class ChessPieceMovementLoader
    {
        public static List<ChessPieceMovementDefinition> GetMovementOptionsByPieceType(ChessPieceType pieceType)
        {
            switch (pieceType)
            {
                case ChessPieceType.Pawn:
                    return loadPawnMovement();

                case ChessPieceType.Bishop:
                    return loadBishopMovement();

                case ChessPieceType.Knight:
                    return loadKnightMovement();

                case ChessPieceType.Rook:
                    return loadRookMovement();

                case ChessPieceType.Queen:
                    return loadQueenMovement();

                case ChessPieceType.King:
                    return loadKingMovement();
                default:
                    throw new Exception("Undefined chess piece");
            }

        }

        private static List<ChessPieceMovementDefinition> loadKingMovement()
        {
            List<ChessPieceMovementDefinition> result = new List<ChessPieceMovementDefinition>();

            List<UserDefinedMovement> kingMovement = new List<UserDefinedMovement>
            {
                new(0, 1),
                new(0, -1),

                new(1, 0),
                new(-1, 0),

                new(-1, -1),
                new(1, -1),

                new(-1, 1),
                new(1, 1)
            };

            ChessPieceMovementDefinition kingMovementDefinition = new ChessPieceMovementDefinition(ChessMovementType.UserDefined, kingMovement);
            result.Add(kingMovementDefinition);

            return result;
        }

        private static List<ChessPieceMovementDefinition> loadQueenMovement()
        {
            List<ChessPieceMovementDefinition> result = new List<ChessPieceMovementDefinition>
            {
                new(ChessMovementType.Horizontal),
                new(ChessMovementType.Vertical),
                new(ChessMovementType.Diagonal)
            };

            return result;
        }

        private static List<ChessPieceMovementDefinition> loadRookMovement()
        {
            List<ChessPieceMovementDefinition> result = new List<ChessPieceMovementDefinition>
            {
                new(ChessMovementType.Horizontal),
                new(ChessMovementType.Vertical)
            };

            return result;
        }

        private static List<ChessPieceMovementDefinition> loadKnightMovement()
        {
            List<ChessPieceMovementDefinition> result = new List<ChessPieceMovementDefinition>();

            List<UserDefinedMovement> knightMovement = new List<UserDefinedMovement>
            {
                new(2, 1),
                new(2, -1),
                new(1, 2),
                new(-1, 2),
                new(-2, 1),
                new(-2, -1),
                new(1, -2),
                new(-1, -2),

            };

            ChessPieceMovementDefinition knightMovementDefinition = new ChessPieceMovementDefinition(ChessMovementType.UserDefined, knightMovement);
            result.Add(knightMovementDefinition);

            return result;
        }

        private static List<ChessPieceMovementDefinition> loadBishopMovement()
        {
            List<ChessPieceMovementDefinition> result = new List<ChessPieceMovementDefinition>
            {
                new(ChessMovementType.Diagonal)
            };
            return result;
        }

        private static List<ChessPieceMovementDefinition> loadPawnMovement()
        {
            List<ChessPieceMovementDefinition> result = new List<ChessPieceMovementDefinition>();

            List<UserDefinedMovement> forwardMovement = new List<UserDefinedMovement>
            {
                new(1, 0)
            };
            ChessPieceMovementDefinition pawnMovementDefinition = new ChessPieceMovementDefinition(ChessMovementType.UserDefined, forwardMovement);
            result.Add(pawnMovementDefinition);

            return result;
        }
    }
}
