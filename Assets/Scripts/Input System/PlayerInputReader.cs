namespace Game.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Game.Player;
    using Game.Interact;
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private PlayerMovement _playerMovement;
        private PlayerInteract _playerInteract;
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInteract = GetComponent<PlayerInteract>();
        }
        public void SetActive(bool value)
        {
            _playerInput.enabled = value;
        }
        private void OnMovement(InputValue value)
        {
            _playerMovement.SetDirection(value.Get<Vector2>());
        }
        private void OnInteract()
        {
            _playerInteract.Interact();
        }
    }
}