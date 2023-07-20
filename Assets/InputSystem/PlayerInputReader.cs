using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputReader : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;
    private PlayerInteract _playerInteract;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInteract = GetComponent<PlayerInteract>();
    }
    private void OnMovement(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        _playerMovement.SetDirection(direction);
        _playerAnimation.SetDirection(direction);
    }
    private void OnInteract()
    {
        _playerInteract.Interact();
    }
}