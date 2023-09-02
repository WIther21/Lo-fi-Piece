namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.UI;
    using Game.UI;
    public class ToolbarCell : Cell
    {
        [Header("Colors")]
        [SerializeField] private Color _unselected;
        [SerializeField] private Color _selected;
        [Header("UI")]
        private Image _cellHolder;
        private Zoom _zoom;
        protected override void Awake()
        {
            base.Awake();
            _cellHolder = GetComponent<Image>();
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
    }
}