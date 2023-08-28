namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.UI;
    using Game.UI;
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Color _unselected;
        [SerializeField] private Color _selected;
        private Image _cellHolder;
        private InventoryItem _item;
        private Zoom _zoom;
        private void Awake()
        {
            _cellHolder = GetComponent<Image>();
            _item = GetComponentInChildren<InventoryItem>();
            _zoom = GetComponent<Zoom>();
        }
        public void Select()
        {
            _zoom.ZoomIn();
            _cellHolder.color = _selected;
        }
        public void Unselect()
        {
            _zoom.ZoomOut();
            _cellHolder.color = _unselected;
        }
        public InventoryItem GetInventoryItem() { return _item; } 
    }
}