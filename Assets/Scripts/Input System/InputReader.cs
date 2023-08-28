namespace Game.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Game.UI;
    using Game.Player;
    using Game.Interact;
    using Game.Dialogue;
    using Game.Inventory;
    public class InputReader : MonoBehaviour
    {
        private GameMenu _gameMenu;
        private PlayerMovement _playerMovement;
        private PlayerInteract _playerInteract;
        private DialogueManager _dialogueManager;
        private ToolbarManager _inventoryManager;
        private void Awake()
        {
            _gameMenu = FindObjectOfType<GameMenu>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _playerInteract = FindObjectOfType<PlayerInteract>();
            _dialogueManager = FindObjectOfType<DialogueManager>();
            _inventoryManager = FindObjectOfType<ToolbarManager>();
        }
        private void OnGameMenu()
        {
            _gameMenu.Interact();
        }
        private void OnMovement(InputValue value)
        {
            _playerMovement.SetDirection(value.Get<Vector2>());
        }
        private void OnInteract()
        {
            _playerInteract.Interact();
        }
        private void OnDialogue()
        {
            _dialogueManager.Interact();
        }
        private void OnInventoryFirst()
        {
            _inventoryManager.SelectCell(0);
        }
        private void OnInventorySecond()
        {
            _inventoryManager.SelectCell(1);
        }
        private void OnInventoryThird()
        {
            _inventoryManager.SelectCell(2);
        }
        private void OnInventoryFourth()
        {
            _inventoryManager.SelectCell(3);
        }
        private void OnInventoryFifth()
        {
            _inventoryManager.SelectCell(4);
        }
        private void OnInventorySixth()
        {
            _inventoryManager.SelectCell(5);
        }
        private void OnInventorySeventh()
        {
            _inventoryManager.SelectCell(6);
        }
        private void OnInventoryEighth()
        {
            _inventoryManager.SelectCell(7);
        }
        private void OnInventoryNinth()
        {
            _inventoryManager.SelectCell(8);
        }
    }
}