namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cellsGroupMenu;
        [SerializeField] private GameObject _cellsGroupMenuToolbar;
        [SerializeField] private GameObject _cellsGroupToolbar;
        [SerializeField] private InventoryItem _draggingItem;
        private Cell[] _cellsMenu;
        private Cell[] _cellsMenuToolbar;
        private Cell[] _cellsToolbar;
        private void Awake()
        {
            _cellsMenu = _cellsGroupMenu.GetComponentsInChildren<Cell>();
            _cellsMenuToolbar = _cellsGroupMenuToolbar.GetComponentsInChildren<Cell>();
            _cellsToolbar = _cellsGroupToolbar.GetComponentsInChildren<Cell>();
        }
        public void Open()
        {
            for (int i = 0; i < _cellsMenuToolbar.Length; i++)
                _cellsMenuToolbar[i].GetInventoryItem().SetItem(_cellsToolbar[i].GetInventoryItem().GetItem());
        }
        public void Close()
        {
            for (int i = 0; i < _cellsToolbar.Length; i++)
                _cellsToolbar[i].GetInventoryItem().SetItem(_cellsMenuToolbar[i].GetInventoryItem().GetItem());
        }
        public void StartDrag(Transform transform)
        {
            InventoryItem item = GetInventoryItem(transform);
            if (item.GetItem() == null)
                return;
            _draggingItem.SetItem(item.GetItem());
            item.SetItem(null);
        }
        public void Drag()
        {
            if (_draggingItem.GetItem() == null)
                return;
            _draggingItem.transform.position = Mouse.current.position.value;
        }
        public void StopDrag(Transform transform)
        {
            if (_draggingItem.GetItem() == null)
                return;
            GetInventoryItem(transform).SetItem(_draggingItem.GetItem());
            _draggingItem.SetItem(null);
        }
        private InventoryItem GetInventoryItem(Transform transform)
        {
            int index = transform.GetSiblingIndex();
            if (transform.parent == _cellsGroupMenu.transform)
                return _cellsMenu[index].GetInventoryItem();
            else
                return _cellsMenuToolbar[index].GetInventoryItem();
        }
    }
}