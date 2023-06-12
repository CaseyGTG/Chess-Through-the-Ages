using Assets.Code.ChessData.Enums;
using System;
using UnityEngine;

namespace Assets.Code.ChessData
{
    [Serializable]
    public class TileLocation
    {
        public TileLocation()
        {
            
        }
        public TileLocation(TileLocationHorizontal horizontal, TileLocationVertical vertical)
        {
            HorizontalLocation = horizontal;
            VerticalLocation = vertical;
        }

        public override string ToString()
        {
            return $"{HorizontalLocation.ToString()}, {VerticalLocation.ToString()}";
        }

        public override bool Equals(object toCompare)
        {
            if (toCompare is TileLocation location)
            {
                return location.HorizontalLocation == HorizontalLocation && location.VerticalLocation == VerticalLocation;
            }
            return base.Equals(toCompare);
        }

        [SerializeField]
        public TileLocationHorizontal HorizontalLocation;

        [SerializeField]
        public TileLocationVertical VerticalLocation;
    }
}