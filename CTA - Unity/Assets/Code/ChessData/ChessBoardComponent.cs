using Assets.Code.ChessData.Enums;
using Assets.Code.ChessData.Pieces;
using Assets.Code.ChessData.Pieces.MovementData;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code.ChessData
{
    public class ChessBoardComponent : MonoBehaviour
    {
        [SerializeField]
        internal ChessPieceComponent currentlySelectedChessPiece;

        public ChessPieceComponent CurrentlySelectedChessPiece
        {
            get
            {
                return currentlySelectedChessPiece;
            }
            set
            {
                currentlySelectedChessPiece = value;

                DeselectAllTiles();

                if (value != null)
                {
                    Debug.Log($"Current value {currentlySelectedChessPiece}, new value {value}");
                    ShowCurrentlyMoveableTiles(value);
                }

            }
        }

        private List<ChessPieceMovementDefinition> piecesMovementOptions = new();

        private void DeselectAllTiles()
        {
            piecesMovementOptions.Clear();
            IList<ChessTileComponent> tiles = this.GetComponentsInChildren<ChessTileComponent>();
            foreach (ChessTileComponent tile in tiles)
            {
                tile.Selectable = false;
            }
        }

        public void ShowCurrentlyMoveableTiles(ChessPieceComponent chessPiece)
        {
            piecesMovementOptions = ChessPieceMovementLoader.GetMovementOptionsByPieceType(chessPiece.PieceType);
            ShowSelectableTiles(chessPiece);
        }

        private void ShowSelectableTiles(ChessPieceComponent chessPiece)
        {
            foreach (ChessPieceMovementDefinition movementDefinition in piecesMovementOptions)
            {
                switch (movementDefinition.MovementType)
                {
                    case ChessMovementType.Diagonal:
                        HighlightDiagonalTilesFrom(chessPiece);
                        break;

                    case ChessMovementType.Horizontal:

                        break;

                    case ChessMovementType.Vertical:

                        break;

                    case ChessMovementType.UserDefined:
                        HighlightUserDefinedTiles(chessPiece, movementDefinition);
                        break;
                }
            }
        }

        public ChessTileComponent GetTileWithLocation(TileLocation location)
        {
            ChessTileComponent[] allTiles = this.GetComponentsInChildren<ChessTileComponent>();
            ChessTileComponent tile = allTiles.Where(resultTile => resultTile.tileLocation.Equals(location)).FirstOrDefault();
            if (tile == null)
            {
                return null;
            }

            return tile;
        }

        private void HighlightUserDefinedTiles(ChessPieceComponent chessPiece, ChessPieceMovementDefinition movementDefinition)
        {
            List<ChessTileComponent> chessTilesToHighlight = new List<ChessTileComponent>();

            TileLocation originLocation = chessPiece.CurrentTileLocation;

            foreach (UserDefinedMovement userDefinedMovement in movementDefinition.UserDefinedMovements)
            {
                TileLocation tileLocationToAdd = new TileLocation();
                tileLocationToAdd.HorizontalLocation = originLocation.HorizontalLocation + userDefinedMovement.Horizontally;
                tileLocationToAdd.VerticalLocation = originLocation.VerticalLocation + userDefinedMovement.Vertically;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(tileLocationToAdd);
                if (tileComponentToAdd != null)
                {
                    chessTilesToHighlight.Add(tileComponentToAdd);
                }
            }

            HighlightTilesFromList(chessTilesToHighlight);
        }

        private void HighlightTilesFromList(List<ChessTileComponent> tilesToHighlight)
        {
            foreach (ChessTileComponent chessTile in tilesToHighlight)
            {
                chessTile.Selectable = true;
            }
        }

        private void HighlightDiagonalTilesFrom(ChessPieceComponent chessPiece)
        {
            List<ChessTileComponent> chessTilesToHighlight = new List<ChessTileComponent>();

            TileLocation originLocation = chessPiece.CurrentTileLocation;

            GetAllDiagonalTilesFromPiece(chessPiece, chessTilesToHighlight);

            HighlightTilesFromList(chessTilesToHighlight);
        }

        private void GetAllDiagonalTilesFromPiece(ChessPieceComponent chessPiece, List<ChessTileComponent> chessTilesToHighlight)
        {
            GetRightUpDiagonalTilesFromPiece(chessPiece, chessTilesToHighlight);
            GetLeftUpDiagonalTilesFromPiece(chessPiece, chessTilesToHighlight);
            GetLeftDownDiagonalTilesFromPiece(chessPiece, chessTilesToHighlight);
        }

        private void GetLeftDownDiagonalTilesFromPiece(ChessPieceComponent chessPiece, List<ChessTileComponent> chessTilesToHighlight)
        {
        }

        private void GetLeftUpDiagonalTilesFromPiece(ChessPieceComponent chessPiece, List<ChessTileComponent> chessTilesToHighlight)
        {
            int BorderUpValue = (int)Enum.GetValues(typeof(TileLocationVertical)).Cast<TileLocationVertical>().Max();
            int borderRightValue = (int)Enum.GetValues(typeof(TileLocationHorizontal)).Cast<TileLocationHorizontal>().Max();
            Debug.Log($"Border up valule {BorderUpValue}");

            int timesToIterate = (int)chessPiece.CurrentTileLocation.VerticalLocation > (int)chessPiece.CurrentTileLocation.HorizontalLocation ? 
                (int)(BorderUpValue - chessPiece.CurrentTileLocation.VerticalLocation) : (int)(borderRightValue - (borderRightValue - chessPiece.CurrentTileLocation.HorizontalLocation));

            Debug.Log(timesToIterate);

            for (int i = 1; i <= timesToIterate; i++)
            {
                TileLocation tileLocationToAdd = new TileLocation();
                tileLocationToAdd.HorizontalLocation = chessPiece.CurrentTileLocation.HorizontalLocation - i;
                tileLocationToAdd.VerticalLocation = chessPiece.CurrentTileLocation.VerticalLocation + i;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(tileLocationToAdd);
                chessTilesToHighlight.Add(tileComponentToAdd);
            }
        }

        private void GetRightUpDiagonalTilesFromPiece(ChessPieceComponent chessPiece, List<ChessTileComponent> chessTilesToHighlight)
        {
            int borderRightValue = (int)Enum.GetValues(typeof(TileLocationHorizontal)).Cast<TileLocationHorizontal>().Max();
            int BorderUpValue = (int)Enum.GetValues(typeof(TileLocationVertical)).Cast<TileLocationVertical>().Max();

            int timesToIterate = (int)chessPiece.CurrentTileLocation.HorizontalLocation > (int)chessPiece.CurrentTileLocation.VerticalLocation ?
                (int)(borderRightValue - chessPiece.CurrentTileLocation.HorizontalLocation) : (int)(BorderUpValue - chessPiece.CurrentTileLocation.VerticalLocation);

            for (int i = 1; i <= timesToIterate; i++)
            {
                TileLocation tileLocationToAdd = new TileLocation();
                tileLocationToAdd.HorizontalLocation = chessPiece.CurrentTileLocation.HorizontalLocation + i;
                tileLocationToAdd.VerticalLocation = chessPiece.CurrentTileLocation.VerticalLocation + i;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(tileLocationToAdd);
                chessTilesToHighlight.Add(tileComponentToAdd);
            }
        }
    }
}