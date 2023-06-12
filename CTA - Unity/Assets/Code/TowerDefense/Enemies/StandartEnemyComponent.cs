using Assets.Code.ChessData;
using Assets.Code.ChessData.Enums;
using Assets.Code.ChessData.Pieces;
using Assets.Code.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

namespace Assets.Code.TowerDefense.Enemies
{
    public class StandartEnemyComponent : MonoBehaviour
    {
        [SerializeField]
        public int Health;

        public int MovementSpeed = 20;
        
        bool currentlyMoving = false;
        Vector2? currentDestination = null;
        int moveSpeed = 20;

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
            if (!currentlyMoving)
            {
                TileLocation nextMove = GetNextMove();
                StartMovingTo(nextMove);
            }

            if (currentlyMoving)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, (Vector2)currentDestination, moveSpeed * Time.deltaTime);
                if(this.transform.position == currentDestination)
                {
                    currentlyMoving = false;
                    currentDestination = null;
                }
            }

        }

        private void StartMovingTo(TileLocation nextMove)
        {
            currentlyMoving = true;
            ChessTileComponent tileToMoveTo = ChessBoardComponent.GetTileWithLocation(nextMove);
            currentDestination = new Vector2(tileToMoveTo.gameObject.transform.position.x, tileToMoveTo.gameObject.transform.parent.position.y);
        }

        private TileLocation GetNextMove()
        {
            List<ChessPieceComponent> kings = GameObject.FindObjectsOfType<ChessPieceComponent>().Where(piece => piece.PieceType == ChessData.Enums.ChessPieceType.King).ToList();
            List<TileLocation> shortestPath = new List<TileLocation>();
            foreach (ChessPieceComponent kingComponent in kings)
            {
                List<TileLocation> PathToKing = FindShortestPath(CurrentTileLocation, kingComponent.CurrentTileLocation);
                if(shortestPath.Count() > PathToKing.Count())
                {
                    shortestPath = PathToKing;
                }
            }

            return shortestPath.FirstOrDefault();
        }


        // Function to find the shortest path between two tile locations
        public List<TileLocation> FindShortestPath(TileLocation start, TileLocation end)
        {
            // Create a queue for BFS
            Queue<List<TileLocation>> queue = new Queue<List<TileLocation>>();

            // Enqueue the start location
            queue.Enqueue(new List<TileLocation> { start });

            // Create a set to keep track of visited locations
            HashSet<TileLocation> visited = new HashSet<TileLocation>();
            visited.Add(start);

            // Perform BFS
            while (queue.Count > 0)
            {
                // Dequeue the current path
                List<TileLocation> path = queue.Dequeue();

                // Get the last location in the path
                TileLocation currentLocation = path[path.Count - 1];

                // Check if the current location is the target location
                if (currentLocation.Equals(end))
                {
                    return path; // Return the shortest path
                }

                // Generate possible next locations
                List<TileLocation> nextLocations = GenerateNextLocations(currentLocation);

                // Enqueue new paths for each next location
                foreach (TileLocation nextLocation in nextLocations)
                {
                    if (!visited.Contains(nextLocation))
                    {
                        // Mark next location as visited
                        visited.Add(nextLocation);

                        // Create a new path and enqueue it
                        List<TileLocation> newPath = new List<TileLocation>(path);
                        newPath.Add(nextLocation);
                        queue.Enqueue(newPath);
                    }
                }
            }

            return null; // No path found
        }

        private List<TileLocation> GenerateNextLocations(TileLocation location)
        {
            List<TileLocation> result = new List<TileLocation>();
            TileLocationVertical? upwards = location.VerticalLocation.Next();
            if (upwards != null)
            {
                result.Add(new(location.HorizontalLocation, (TileLocationVertical)upwards));
            }

            TileLocationVertical? downwards = location.VerticalLocation.Previous();
            if (downwards != null)
            {
                result.Add(new(location.HorizontalLocation, (TileLocationVertical)downwards));
            }

            TileLocationHorizontal? right = location.HorizontalLocation.Next();
            if (right != null)
            {
                result.Add(new((TileLocationHorizontal)right, location.VerticalLocation));
            }

            TileLocationHorizontal? left = location.HorizontalLocation.Previous();
            if (left != null)
            {
                result.Add(new((TileLocationHorizontal)left, location.VerticalLocation));
            }

            return result;
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