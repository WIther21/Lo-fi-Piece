namespace Game.Input
{
    using UnityEngine;
    using Game.UI;
    using Game.Dialogue;
    using Game.Inventory;
    public class InputReader : MonoBehaviour
    {
        private GameMenu _gameMenu;
        private DialogueManager _dialogueManager;
        private ToolbarManager _inventoryManager;
        private void Awake()
        {
            _gameMenu = FindObjectOfType<GameMenu>();
            _dialogueManager = FindObjectOfType<DialogueManager>();
            _inventoryManager = FindObjectOfType<ToolbarManager>();
        }
        private void OnGameMenu()
        {
            _gameMenu.Interact();
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