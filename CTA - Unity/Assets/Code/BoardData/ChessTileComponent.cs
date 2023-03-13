using Assets.Code.BoardData.Enums;
using Assets.Code.Interactions;
using Assets.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.BoardData
{
    public class ChessTileComponent : InteractableComponent
    {
        [SerializeField]
        public TileLocation tileLocation = new();

        public override void Interact()
        {
            Debug.Log(tileLocation.ToString());
        }
    }
}
