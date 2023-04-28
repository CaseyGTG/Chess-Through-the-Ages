using Assets.Code.ChessData.Enums;
using Assets.Code.Interactions;
using System;
using UnityEngine;

namespace Assets.Code.ChessData.Pieces
{
    public class ChessPieceComponent : InteractableComponent
    {
        [SerializeField]
        public ChessPieceType PieceType;

        [SerializeField]
        public ChessColor Color;

        public bool CurrentlyMoving = false;

        public Vector2? PointToMoveTo;

        public float moveSpeed = 1;

        public TileLocation CurrentTileLocation
        {
            get
            {
                RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.up, 0f, LayerMask.GetMask("ChessBoard"));
                if (hit.collider != null)
                {
                    ChessTileComponent currentTile = hit.transform.GetComponentInChildren<ChessTileComponent>() ??
                        throw new Exception($"Hit something with no ChessTileComponent with name {hit.transform.name}");
                    return currentTile.tileLocation;
                }
                else
                {
                    throw new Exception("Could not find any tile underneath chess piece.");
                }
            }
        }

        private void Start()
        {
            ChessBoardComponent.GetTileWithLocation(CurrentTileLocation).Occupied = true;
        }

        public override string ToString()
        {
            return $"{Color} {PieceType}";
        }

        private void Update()
        {
            MoveToDestination();
        }

        private void MoveToDestination()
        {
            if (PointToMoveTo != null)
            {
                CurrentlyMoving = true;
                this.transform.position = Vector2.MoveTowards(this.transform.position, (Vector2)PointToMoveTo, moveSpeed * Time.deltaTime);
                if (this.transform.position == PointToMoveTo)
                {
                    PointToMoveTo = null;

                    CurrentlyMoving = false;
                }
            }
        }

        public void StartMovingTo(TileLocation location)
        {
            ChessTileComponent currentTile = ChessBoardComponent.GetTileWithLocation(CurrentTileLocation);
            currentTile.Occupied = false;
            ChessTileComponent tileToMoveTo = ChessBoardComponent.GetTileWithLocation(location);
            PointToMoveTo = new Vector2(tileToMoveTo.gameObject.transform.position.x, tileToMoveTo.gameObject.transform.parent.position.y);
            Debug.Log($"Moving {this} to {location} on {PointToMoveTo}");
            tileToMoveTo.Occupied = true;
            ChessBoardComponent.CurrentlySelectedChessPiece = null;
        }

        public override void Interact()
        {
            if (!CurrentlyMoving)
            {
                Debug.Log(this.ToString());
                SelectOrDeselectPiece();
            }
        }

        private void SelectOrDeselectPiece()
        {
            ChessBoardComponent.CurrentlySelectedChessPiece = this;
        }
    }
}