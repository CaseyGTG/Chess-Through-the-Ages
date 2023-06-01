using Assets.Code.ChessData;
using Assets.Code.ChessData.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.TowerDefense.Enemy
{
    public class EnemyComponent : MonoBehaviour
    {
        [SerializeField]
        public int Health;

        public int MovementSpeed = 20;
        private bool Moving = false;

        [SerializeField]
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

        private void Update()
        {
            Move();

        }

        private void Move()
        {
            if (!Moving)
            {
                TileLocation tileLocation = GetTileToMoveToNearestKing();
            }
            
        }

        private TileLocation GetTileToMoveToNearestKing()
        {
            List<ChessPieceComponent> kings = GameObject.FindObjectsOfType<ChessPieceComponent>().Where(piece => piece.PieceType == ChessData.Enums.ChessPieceType.King).ToList();
            List<TileLocation> shortestPath = new List<TileLocation>();
            foreach (ChessPieceComponent pieceLocation in kings)
            {
                List<TileLocation> PathToKing = FindShortestPathToPiece(CurrentTileLocation, pieceLocation);
                if(shortestPath.Count() > PathToKing.Count())
                {
                    shortestPath = PathToKing;
                }
            }

            return shortestPath.FirstOrDefault();

        }

        private List<TileLocation> FindShortestPathToPiece(TileLocation currentLocation, ChessPieceComponent kingsLocation)
        {
            Queue<TileLocation> Queue = new Queue<TileLocation>();
            Queue.Append(new(currentLocation.HorizontalLocation, currentLocation.VerticalLocation++));
            TileLocation DownwardsLocation = new(currentLocation.HorizontalLocation, currentLocation.VerticalLocation--);
            TileLocation RightLocation = new(currentLocation.HorizontalLocation++, currentLocation.VerticalLocation);
            TileLocation LeftLocation = new(currentLocation.HorizontalLocation--, currentLocation.VerticalLocation);

        }

        private void Awake()
        {
            Debug.Log("Enemy loaded");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Trigger from enemy");
        }
    }
}