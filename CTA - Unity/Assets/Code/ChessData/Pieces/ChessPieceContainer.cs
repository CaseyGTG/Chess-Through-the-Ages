using Assets.Code.ChessData.Enums;
using Assets.Code.ChessData.Pieces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessPieceContainer : MonoBehaviour
{
    public static ChessPieceContainer instance;

    public List<GameObject> pieces = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public static GameObject getChessPiecePrefabByType(ChessPieceType type)
    {
        if (instance.pieces.Count == 0)
        {
            throw new System.Exception("Chess pieces were not set in chess pieces object.");
        }
        return instance.pieces.Where(chessPiece => chessPiece.GetComponent<ChessPieceComponent>().PieceType == type).FirstOrDefault();
    }
}