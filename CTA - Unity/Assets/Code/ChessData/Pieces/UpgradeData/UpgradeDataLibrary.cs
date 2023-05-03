using Assets.Code.ChessData.Enums;
using System.Collections.Generic;

namespace Assets.Code.ChessData.Pieces.UpgradeData
{
    internal static class UpgradeDataLibrary
    {
        private static Dictionary<ChessPieceType, List<UpgradeDataModel>> upgradeOptionsDictionary = new System.Collections.Generic.Dictionary<ChessPieceType, List<UpgradeDataModel>>()
        {
            {
                ChessPieceType.Pawn,
                new List<UpgradeDataModel>{
                    new UpgradeDataModel(ChessPieceType.Knight, 150),
                    new UpgradeDataModel(ChessPieceType.Bishop, 150)
                }
            },
            {
                ChessPieceType.Rook,
                new List<UpgradeDataModel>
                {
                    new UpgradeDataModel(ChessPieceType.King, 2000)
                }
            },
            {
                ChessPieceType.Bishop,
                new List<UpgradeDataModel>
                {
                    new UpgradeDataModel(ChessPieceType.Queen, 1000)
                }
            },
            {
                ChessPieceType.Knight,
                new List<UpgradeDataModel>
                {
                    new UpgradeDataModel(ChessPieceType.Queen, 1000),
                    new UpgradeDataModel(ChessPieceType.King, 2000)
                }
            },
            {
                ChessPieceType.King,
                new List<UpgradeDataModel>()
            },
            {
                ChessPieceType.Queen,
                new List<UpgradeDataModel>()
            }
        };

        public static List<UpgradeDataModel> GetUpgradeDataForChessPiece(ChessPieceType pieceType)
        {
            return upgradeOptionsDictionary[pieceType];
        }
    }
}