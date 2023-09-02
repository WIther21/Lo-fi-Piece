namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    public class InventoryItem : MonoBehaviour
    {
        [Header("Item")]
        [SerializeField] private ItemSO _item;
        [SerializeField] private int _amount;
        [Header("UI")]
        private Image _iconHolder;
        private TextMeshProUGUI _textHolder;
        public ItemSO Item
        {
            get { return _item; }
            set
            {
                if (_item != null && value != null)
                    return;
                _item = value;
                _amount = 1;
                UpdateIcon();
            }
        }
        public int Amount
        {
            get { return _amount; }
            set
            {
                if (Item == null)
                    _amount = 0;
                else
                    _amount = Mathf.Clamp(value, 1, _item.MaxAmount);
                UpdateIcon();
            }
        }
        private void Awake()
        {
            _iconHolder = GetComponent<Image>();
            _textHolder = GetComponentInChildren<TextMeshProUGUI>();
        }
        private void OnValidate()
        {
            if (_item == null)
            {
                _amount = 0;
                return;
            }
            if (_amount < 1)
                _amount = 1;
            if (_amount > _item.MaxAmount)
                _amount = _item.MaxAmount;
        }
        private void Start()
        {
            UpdateIcon();
        }
        private void UpdateIcon()
        {
            if (_item == null)
            {
                _iconHolder.color = Color.clear;
                _textHolder.color = Color.clear;
            }
            else
            {
                _iconHolder.color = Color.white;
                _iconHolder.sprite = _item.Icon;
                _iconHolder.preserveAspect = true;
                if (_amount < 2)
                    return;
                _textHolder.color = Color.white;
                _textHolder.text = _amount.ToString();
            }
        }
    }
}