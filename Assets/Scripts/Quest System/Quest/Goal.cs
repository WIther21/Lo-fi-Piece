namespace Game.Quest
{
    using UnityEngine;
    [System.Serializable]
    public struct Goal
    {
        [SerializeField] [TextArea(1, 3)] private string _text;
        [SerializeField] private int _requiredAmount;
        [SerializeField] private string[] _actionKeys;
        public string GetText() { return _text; }
        public int GetRequiredAmount() { return _requiredAmount; }
        public string[] GetKeys() { return _actionKeys; }
    }
}