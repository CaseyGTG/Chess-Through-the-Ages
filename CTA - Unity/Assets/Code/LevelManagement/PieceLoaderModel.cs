using Assets.Code.ChessData;
using Assets.Code.ChessData.Enums;
using System;
using UnityEngine;

namespace Assets.Code.LevelManagement
{
    [Serializable]
    public class PieceLoaderModel
    {
        [SerializeField]
        public ChessPieceType PieceType;

        [SerializeField]
        public TileLocation WhereToLoadPiece;
    }
}