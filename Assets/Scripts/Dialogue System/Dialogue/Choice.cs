namespace Game.Dialogue
{
    using UnityEngine;
    [System.Serializable]
    public struct Choice
    {
        [SerializeField] private string _text;
        [SerializeField] private Color _color;
        [SerializeField] private DialogueSO _dialogue;
        public string GetText() { return _text; }
        public Color GetColor() { return _color; }
        public DialogueSO GetDialogue() { return _dialogue; }
    }
}