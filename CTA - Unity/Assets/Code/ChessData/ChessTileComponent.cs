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
                }
                selectable = value;
            }
        }

        public override void Interact()
        {
            Debug.Log(tileLocation.ToString());
        }

        private void Awake()
        {
            selectionParticles = GetComponentInChildren<ParticleSystem>() ?? throw new MissingComponentException();
            Selectable = false;
        }
    }
}