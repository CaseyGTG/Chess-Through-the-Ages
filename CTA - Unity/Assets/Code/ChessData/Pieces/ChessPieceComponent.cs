using Assets.Code.ChessData.Enums;
using Assets.Code.ChessData.Pieces.MovementData;
using Assets.Code.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ChessData.Pieces
{
    public class ChessPieceComponent : InteractableComponent
    {
        [SerializeField]
        public ChessPieceType PieceType;

        [SerializeField]
        public ChessColor Color;

        public TileLocation CurrentTileLocation { get
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

        public override string ToString()
        {
            return $"{Color} {PieceType}";
        }

        public override void Interact()
        {
            Debug.Log(this.ToString());

            ChessBoardComponent chessBoardComponent = FindObjectOfType<ChessBoardComponent>() ?? throw new MissingComponentException();

            if(chessBoardComponent.CurrentlySelectedChessPiece != this)
            {
                chessBoardComponent.CurrentlySelectedChessPiece = this;
            }
            else
            {
                chessBoardComponent.CurrentlySelectedChessPiece = null;
            }
        }
    }
}
