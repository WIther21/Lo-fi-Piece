namespace Game.Inventory
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        public Sprite GetIcon() { return _icon; }
    }
}