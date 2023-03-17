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
                        HighlightHorizontalTilesFrom(chessPiece);
                        break;

                    case ChessMovementType.Vertical:

                        break;

                    case ChessMovementType.UserDefined:
                        HighlightUserDefinedTiles(chessPiece, movementDefinition);
                        break;
                }
            }
        }

        private void HighlightHorizontalTilesFrom(ChessPieceComponent chessPiece)
        {
            List<ChessTileComponent> chessTilesToHighlight = new List<ChessTileComponent>();

            TileLocation currentLocation = chessPiece.CurrentTileLocation;

            int leftIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation - leftIterator;
                newTileLocation.VerticalLocation = currentLocation.VerticalLocation;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null)
                {
                    break;
                }
                chessTilesToHighlight.Add(tileComponentToAdd);
                leftIterator++;
            }

            int rightIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation + rightIterator;
                newTileLocation.VerticalLocation = currentLocation.VerticalLocation;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null)
                {
                    break;
                }
                chessTilesToHighlight.Add(tileComponentToAdd);
                rightIterator++;
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

            GetAllDiagonalTilesFromPiece(chessPiece, chessTilesToHighlight);

            HighlightTilesFromList(chessTilesToHighlight);
        }

        private void GetAllDiagonalTilesFromPiece(ChessPieceComponent chessPiece, List<ChessTileComponent> chessTilesToHighlight)
        {
            TileLocation currentLocation = chessPiece.CurrentTileLocation;

            int upRightIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation + upRightIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation + upRightIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null)
                {
                    break;
                }
                chessTilesToHighlight.Add(tileComponentToAdd);
                upRightIterator++;
            }

            int downLeftIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation - downLeftIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation - downLeftIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null)
                {
                    break;
                }
                chessTilesToHighlight.Add(tileComponentToAdd);
                downLeftIterator++;
            }

            int upLeftIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation - upLeftIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation + upLeftIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null)
                {
                    break;
                }
                chessTilesToHighlight.Add(tileComponentToAdd);
                upLeftIterator++;
            }


            int downRightIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation + downRightIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation - downRightIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null)
                {
                    break;
                }
                chessTilesToHighlight.Add(tileComponentToAdd);
                downRightIterator++;
            }
        }
    }
}