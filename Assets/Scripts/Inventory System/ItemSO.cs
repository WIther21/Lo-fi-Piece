namespace Game.Inventory
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        public string GetName() { return _name; }
        public Sprite GetIcon() { return _icon; }
    }
}