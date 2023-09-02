namespace Game.Inventory
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _maxAmount = 1;
        public Sprite Icon { get { return _icon; } }
        public int MaxAmount { get { return _maxAmount; } }
        private void OnValidate()
        {
            if (_maxAmount < 1)
                _maxAmount = 1;
        }
    }
}