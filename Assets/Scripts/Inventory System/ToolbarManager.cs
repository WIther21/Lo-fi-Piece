namespace Game.Inventory
{
    using UnityEngine;
    public class ToolbarManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cellsGroup;
        private Cell[] _cells;
        private int _currentIndex;
        private void Awake()
        {
            _cells = _cellsGroup.GetComponentsInChildren<Cell>();
        }
        private void Start()
        {
            _cells[_currentIndex].Select();
        }
        public void SelectCell(int index)
        {
            _cells[_currentIndex].Unselect();
            _currentIndex = Mathf.Clamp(index, 0, _cells.Length - 1);
            _cells[_currentIndex].Select();
        }
        public void GiveItem(ItemSO item)
        {
            foreach (var cell in _cells)
            {
                if (cell.GetInventoryItem().GetItem() != null)
                    continue;
                else
                {
                    cell.GetInventoryItem().SetItem(item);
                    break;
                }
            }
        }
        public InventoryItem GetCurrentItem() { return _cells[_currentIndex].GetInventoryItem(); }
    }
}