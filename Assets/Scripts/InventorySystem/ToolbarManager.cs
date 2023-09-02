namespace Game.Inventory
{
    using UnityEngine;
    public class ToolbarManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cellsGroup;
        private InventoryManager _inventoryManager;
        private ToolbarCell[] _cells;
        private int _currentIndex;
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _cells = _cellsGroup.GetComponentsInChildren<ToolbarCell>();
        }
        private void Start()
        {
            _cells[_currentIndex].Select();
        }
        public void SelectCell(int index)
        {
            if (_currentIndex == index)
                return;
            _cells[_currentIndex].Unselect();
            _currentIndex = Mathf.Clamp(index, 0, _cells.Length - 1);
            _cells[_currentIndex].Select();
            _inventoryManager.CurrentItem = _cells[_currentIndex].InventoryItem;
        }
    }
}