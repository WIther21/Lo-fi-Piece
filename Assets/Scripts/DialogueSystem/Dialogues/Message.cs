namespace Game.Dialogue
{
    using UnityEngine;
    [System.Serializable]
    public struct Message
    {
        [SerializeField] [TextArea(1, 3)] private string _text;
        [SerializeField] private float _speed;
        [SerializeField] private ActorSO _actor;
        [SerializeReference] private string _actionKey;
        public string GetText() { return _text; }
        public float GetSpeed() { return _speed; }
        public ActorSO GetActor() { return _actor; }
        public string GetActionKey() { return _actionKey; }
    }
}