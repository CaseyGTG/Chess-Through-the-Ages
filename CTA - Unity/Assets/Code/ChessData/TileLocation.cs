using Assets.Code.ChessData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ChessData
{
    [Serializable]
    public class TileLocation
    {
        public override string ToString()
        {
            return $"{HorizontalLocation.ToString()}, {VerticalLocation.ToString()}";
        }
        [SerializeField]
        public TileLocationHorizontal HorizontalLocation;

        [SerializeField]
        public TileLocationVertical VerticalLocation;
    }
}
