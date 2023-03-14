using Assets.Code.ChessData.Enums;
using Assets.Code.ChessData.Pieces;
using Assets.Code.ChessData.Pieces.MovementData;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Code.ChessData
{
    public class ChessBoardComponent : MonoBehaviour
    {
        private ChessPieceComponent currentlySelectedChessPiece;

        public ChessPieceComponent? CurrentlySelectedChessPiece
        {
            get
            {
                return currentlySelectedChessPiece;
            }
            set
            {
                DeselectAllTiles();

                if (value != null || value != currentlySelectedChessPiece)
                {
                    ShowCurrentlyMoveableTiles(value);
                }

                currentlySelectedChessPiece = value;
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
            foreach(ChessPieceMovementDefinition movementDefinition in piecesMovementOptions)
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

        private ChessTileComponent GetTileWithLocation(TileLocation location)
        {
            ChessTileComponent[] allTiles = this.GetComponentsInChildren<ChessTileComponent>();
            Debug.Log(allTiles.Count());
            IList<ChessTileComponent> tile = allTiles.Where(resulTile => resulTile.tileLocation == location).ToList();

            if(tile.Count() == 0)
            {
                throw new Exception($"No tiles with location {location}");
            }

            return tile.FirstOrDefault();
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
                chessTilesToHighlight.Add(GetTileWithLocation(tileLocationToAdd));
            }

            foreach(ChessTileComponent chessTile in chessTilesToHighlight)
            {
                chessTile.Selectable = true;
            }
        }

        private void HighlightDiagonalTilesFrom(ChessPieceComponent chessPiece)
        {



        }

        
    }
}