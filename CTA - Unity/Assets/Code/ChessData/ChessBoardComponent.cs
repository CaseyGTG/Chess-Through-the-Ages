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
                DeselectAllTiles();

                if (currentlySelectedChessPiece != value)
                {
                    currentlySelectedChessPiece = value;
                    ShowCurrentlyMoveableTiles(currentlySelectedChessPiece);
                }
                else
                {
                    currentlySelectedChessPiece = null;
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
                        HighlightTilesFromList(GetAllDiagonalTilesFromPiece(chessPiece));
                        break;

                    case ChessMovementType.Horizontal:
                        HighlightTilesFromList(GetAllHorizontalTiles(chessPiece));
                        break;

                    case ChessMovementType.Vertical:
                        HighlightTilesFromList(GetAllVerticalTiles(chessPiece));
                        break;

                    case ChessMovementType.UserDefined:
                        HighlightTilesFromList(GetAllUserDefinedTiles(chessPiece, movementDefinition));
                        break;
                }
            }
        }

        private List<ChessTileComponent> GetAllVerticalTiles(ChessPieceComponent chessPiece)
        {
            List<ChessTileComponent> result = new List<ChessTileComponent>();

            TileLocation currentLocation = chessPiece.CurrentTileLocation;

            int upIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation;
                newTileLocation.VerticalLocation = currentLocation.VerticalLocation + upIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                upIterator++;
            }

            int downIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation;
                newTileLocation.VerticalLocation = currentLocation.VerticalLocation - downIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                downIterator++;
            }

            return result;
        }

        private List<ChessTileComponent> GetAllHorizontalTiles(ChessPieceComponent chessPiece)
        {
            List<ChessTileComponent> result = new List<ChessTileComponent>();

            TileLocation currentLocation = chessPiece.CurrentTileLocation;

            int leftIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation - leftIterator;
                newTileLocation.VerticalLocation = currentLocation.VerticalLocation;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                leftIterator++;
            }

            int rightIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation + rightIterator;
                newTileLocation.VerticalLocation = currentLocation.VerticalLocation;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                rightIterator++;
            }

            return result;
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

        private List<ChessTileComponent> GetAllUserDefinedTiles(ChessPieceComponent chessPiece, ChessPieceMovementDefinition movementDefinition)
        {
            List<ChessTileComponent> result = new List<ChessTileComponent>();

            TileLocation originLocation = chessPiece.CurrentTileLocation;

            foreach (UserDefinedMovement userDefinedMovement in movementDefinition.UserDefinedMovements)
            {
                TileLocation tileLocationToAdd = new TileLocation();
                tileLocationToAdd.HorizontalLocation = originLocation.HorizontalLocation + userDefinedMovement.Horizontally;
                tileLocationToAdd.VerticalLocation = originLocation.VerticalLocation + userDefinedMovement.Vertically;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(tileLocationToAdd);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    continue;
                }
                result.Add(tileComponentToAdd);
            }

            return result;
        }

        private void HighlightTilesFromList(List<ChessTileComponent> tilesToHighlight)
        {
            foreach (ChessTileComponent chessTile in tilesToHighlight)
            {
                chessTile.Selectable = true;
            }
        }

        private List<ChessTileComponent> GetAllDiagonalTilesFromPiece(ChessPieceComponent chessPiece)
        {
            List<ChessTileComponent> result = new List<ChessTileComponent>();
            TileLocation currentLocation = chessPiece.CurrentTileLocation;

            int upRightIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation + upRightIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation + upRightIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                upRightIterator++;
            }

            int downLeftIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation - downLeftIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation - downLeftIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                downLeftIterator++;
            }

            int upLeftIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation - upLeftIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation + upLeftIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                upLeftIterator++;
            }


            int downRightIterator = 1;
            while (true)
            {
                TileLocation newTileLocation = new TileLocation();
                newTileLocation.HorizontalLocation += (int)currentLocation.HorizontalLocation + downRightIterator;
                newTileLocation.VerticalLocation += (int)currentLocation.VerticalLocation - downRightIterator;
                ChessTileComponent tileComponentToAdd = GetTileWithLocation(newTileLocation);
                if (tileComponentToAdd == null || tileComponentToAdd.Occupied)
                {
                    break;
                }
                result.Add(tileComponentToAdd);
                downRightIterator++;
            }

            return result;
        }
    }
}