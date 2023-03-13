using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.BoardData
{
    public class ChessBoard : MonoBehaviour
    {
        private IList<ChessTileComponent> chessTiles { get; set; }

        public ChessTileComponent GetChessTileWithLocation { get; set; }
    }
}