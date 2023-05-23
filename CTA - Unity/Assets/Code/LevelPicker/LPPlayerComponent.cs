using LevelPicker.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Assets.Code.LevelPicker
{
    public class LPPlayerComponent : MonoBehaviour
    {
        public Rigidbody2D body;

        private LevelPickerInputController inputController;

        private Vector2 MoveDirection = Vector2.zero;

        private int MoveSpeedMultiplier = 10;

        private LPLevelComponent levelComponent = null;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();

            InitInput();
        }

        private void InitInput()
        {
            inputController = new LevelPickerInputController();
            if (inputController != null)
            {
                inputController.Player.Enable();
            }

            inputController.Player.Interact.started += Action_Activated;
        }

        private void Action_Activated(InputAction.CallbackContext obj)
        {
            if(levelComponent == null)
            {
                throw new System.Exception("Level not assigned in inspector.");
            }

            SceneManager.LoadSceneAsync((int)levelComponent.SceneToLoad);
        }

        private void Update()
        {
            MoveDirection = inputController.Player.Move.ReadValue<Vector2>();
            body.MovePosition((Vector2)transform.position + new Vector2(MoveDirection.x * Time.deltaTime, MoveDirection.y * Time.deltaTime) * MoveSpeedMultiplier);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<LPLevelComponent>() != null)
            {
                levelComponent = collision.gameObject.GetComponent<LPLevelComponent>();
                levelComponent.Expand();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            levelComponent.Shrink();
            levelComponent = null;
        }
    }
}