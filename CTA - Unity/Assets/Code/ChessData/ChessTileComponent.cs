using Assets.Code.Interactions;
using UnityEngine;

namespace Assets.Code.ChessData
{
    public class ChessTileComponent : InteractableComponent
    {
        [SerializeField]
        public TileLocation tileLocation = new();

        private ParticleSystem selectionParticles;

        private bool selectable;

        public bool Selectable
        {
            get
            {
                return selectable;
            }
            set
            {
                if (value)
                {
                    selectionParticles.Play();
                }
                else
                {
                    selectionParticles.Stop();
                    selectionParticles.Clear();
                }
                selectable = value;
            }
        }

        [SerializeField]
        public bool Occupied = false;

        public override void Interact()
        {
            if (selectable && !Occupied)
            {
                ChessBoardComponent.CurrentlySelectedChessPiece.StartMovingTo(this.tileLocation);
            }
            Debug.Log(tileLocation.ToString());
        }

        private void Awake()
        {
            selectionParticles = GetComponentInChildren<ParticleSystem>() ?? throw new MissingComponentException();
            selectionParticles.Stop();
            Selectable = false;
        }
    }
}