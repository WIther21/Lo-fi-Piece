namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.UI;
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private ItemSO _item;
        private Image _iconHolder;
        private void Awake()
        {
            _iconHolder = GetComponent<Image>();
        }
        private void Start()
        {
            UpdateIcon();
        }
        public ItemSO GetItem() { return _item; }
        public void SetItem(ItemSO item)
        {
            _item = item;
            UpdateIcon();
        }
        private void UpdateIcon()
        {
            if (_item == null)
                _iconHolder.color = Color.clear;
            else
            {
                _iconHolder.color = Color.white;
                _iconHolder.sprite = _item.GetIcon();
                _iconHolder.preserveAspect = true;
            }
        }
    }
}