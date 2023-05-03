using Assets.Code.Exceptions;
using Assets.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Interactions
{
    public class InteractableComponent : MonoBehaviour, IInteractableComponent
    {
        public Collider2D interactionCollider { get; set; }

        private void Awake()
        {
            interactionCollider = GetComponent<Collider2D>() ?? throw new ComponentNotFoundException();
        }

        private void OnMouseDown()
        {
            Interact();
        }

        public virtual void Interact()
        {
            Debug.Log($"Interacted with this {this.name}.");
        }
        
    }
}
