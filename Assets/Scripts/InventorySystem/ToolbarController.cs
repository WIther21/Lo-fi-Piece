namespace Game.Inventory
{
    using UnityEngine;
    public class ToolbarController : MonoBehaviour
    {
        private ToolbarManager _inventoryManager;
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<ToolbarManager>();
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