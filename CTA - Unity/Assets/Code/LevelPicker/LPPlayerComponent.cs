using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Code.LevelPicker
{
    public class LPPlayerComponent : MonoBehaviour
    {
        public Rigidbody2D body;

        private PlayerInput playerInput;

        private Vector2 MoveDirection = Vector2.zero;

        private int MoveSpeedMultiplier = 10;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveDirection = playerInput.actions.ElementAt(0).ReadValue<Vector2>();
            body.MovePosition((Vector2)transform.position + new Vector2(MoveDirection.x * Time.deltaTime, MoveDirection.y * Time.deltaTime) * MoveSpeedMultiplier);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<LPLevelComponent>() != null)
            {
                collision.gameObject.GetComponent<LPLevelComponent>().Expand();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<LPLevelComponent>() != null)
            {
                collision.gameObject.GetComponent<LPLevelComponent>().Shrink();
            }
        }
    }
}