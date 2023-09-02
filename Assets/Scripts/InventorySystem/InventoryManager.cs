namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    public class InventoryManager : MonoBehaviour
    {
        [Header("CellsGroups")]
        [SerializeField] private GameObject _cellsGroupInventory;
        [SerializeField] private GameObject _cellsGroupInventoryToolbar;
        [SerializeField] private GameObject _cellsGroupToolbar;
        [Header("Items")]
        [HideInInspector] public InventoryItem CurrentItem;
        [SerializeField] private InventoryItem _draggingItem;
        [Header("Cells")]
        private ToolbarCell[] _cellsInventory;
        private ToolbarCell[] _cellsInventoryToolbar;
        private ToolbarCell[] _cellsToolbar;
        private void Awake()
        {
            _cellsInventory = _cellsGroupInventory.GetComponentsInChildren<ToolbarCell>();
            _cellsInventoryToolbar = _cellsGroupInventoryToolbar.GetComponentsInChildren<ToolbarCell>();
            _cellsToolbar = _cellsGroupToolbar.GetComponentsInChildren<ToolbarCell>();
        }
        public void Open()
        {
            for (int i = 0; i < _cellsInventoryToolbar.Length; i++)
                SetInventoryCell(i);
        }
        public void Close()
        {
            for (int i = 0; i < _cellsToolbar.Length; i++)
                SetToolbarCell(i);
        }
        private void SetInventoryCell(int index)
        {
            InventoryItem inventory = _cellsInventoryToolbar[index].InventoryItem;
            InventoryItem toolbar = _cellsToolbar[index].InventoryItem;
            inventory.Item = toolbar.Item;
            inventory.Amount = toolbar.Amount;
        }
        private void SetToolbarCell(int index)
        {
            InventoryItem menu = _cellsInventoryToolbar[index].InventoryItem;
            InventoryItem toolbar = _cellsToolbar[index].InventoryItem;
            toolbar.Item = menu.Item;
            toolbar.Amount = menu.Amount;
        }
        public void GiveItem(ItemSO item)
        {
            foreach (var cell in _cellsToolbar)
            {
                if (SetCell(cell, item))
                    return;
            }
            foreach (var cell in _cellsInventory)
            {
                if (SetCell(cell, item))
                    return;
            }
            Debug.Log("Item Not Added");
        }
        private bool SetCell(Cell cell, ItemSO item)
        {
            InventoryItem inventoryItem = cell.InventoryItem;
            if (inventoryItem.Item == null)
            {
                inventoryItem.Item = item;
                return true;
            }
            if (inventoryItem.Amount >= inventoryItem.Item.MaxAmount)
                return false;
            inventoryItem.Amount++;
            return true;
        }
        public void StartDrag(Transform transform)
        {
            InventoryItem inventoryItem = GetInventoryItem(transform);
            if (inventoryItem.Item == null)
                return;
            _draggingItem.Item = inventoryItem.Item;
            _draggingItem.Amount = inventoryItem.Amount;
            inventoryItem.Item = null;
        }
        public void Drag()
        {
            if (_draggingItem.Item == null)
                return;
            _draggingItem.transform.position = Mouse.current.position.value;
        }
        public void StopDrag(Transform transform)
        {
            if (_draggingItem.Item == null)
                return;
            InventoryItem inventoryItem = GetInventoryItem(transform);
            inventoryItem.Item = _draggingItem.Item;
            inventoryItem.Amount = _draggingItem.Amount;
            _draggingItem.Item = null;
        }
        private InventoryItem GetInventoryItem(Transform transform)
        {
            int index = transform.GetSiblingIndex();
            if (transform.parent == _cellsGroupInventory.transform)
                return _cellsInventory[index].InventoryItem;
            else
                return _cellsInventoryToolbar[index].InventoryItem;
        }
    }
}