namespace Game.Quest
{
    using UnityEngine;
    [System.Serializable]
    public struct Reward
    {
        [SerializeField] private string _item;
        [SerializeField] private int _amount;
        public string GetItem() { return _item; }
        public int GetAmount() { return _amount; }
    }
}