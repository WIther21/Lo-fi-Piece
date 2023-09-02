namespace Game.Dialogue
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Game/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        [SerializeField] private Message[] _messages;
        [SerializeField] private Choice[] _choices;
        public Message[] GetMessages() { return _messages; }
        public Choice[] GetChoices() { return _choices; }
    }
}