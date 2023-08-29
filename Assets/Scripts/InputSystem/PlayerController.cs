namespace Game.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Game.Player;
    public class PlayerController : MonoBehaviour
    {
        private PlayerManager _manager;
        private void Awake()
        {
            _manager = FindObjectOfType<PlayerManager>();
        }
        private void OnMovement(InputValue value)
        {
            Vector2 direction = value.Get<Vector2>();
            _manager.GetMovement().SetDirection(direction);
            _manager.GetAnimation().SetMoving(direction);
        }
    }
}