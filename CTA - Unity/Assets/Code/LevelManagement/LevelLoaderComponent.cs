using Assets.Code.ChessData;
using Assets.Code.ChessData.Pieces.UpgradeData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.LevelManagement
{
    public class LevelLoaderComponent : MonoBehaviour
    {
        [SerializeField]
        private List<PieceLoaderModel> piecesToLoad;

        [SerializeField]
        public GameObject ChessPiecesObject;

        private void Start()
        {
            if (piecesToLoad == null || piecesToLoad.Count == 0)
            {
                throw new Exception("No chess pieces to load.");
            }

            if (ChessPiecesObject == null)
            {
                throw new Exception("Chess pieces object not assigned in inspector.");
            }

            foreach (var piece in piecesToLoad)
            {
                GameObject newChessPiece = Instantiate(ChessPieceContainer.getChessPiecePrefabByType(piece.PieceType));
                ChessTileComponent currentTile = ChessBoardComponent.GetTileWithLocation(piece.WhereToLoadPiece);
                newChessPiece.transform.position = currentTile.transform.position;
                newChessPiece.transform.SetParent(ChessPiecesObject.transform);
            }
        }
    }
}