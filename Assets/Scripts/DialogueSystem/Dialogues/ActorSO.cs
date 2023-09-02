namespace Game.Dialogue
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Actor", menuName = "Game/Actor")]
    public class ActorSO : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _color;
        public string GetName() { return _name; }
        public Color GetColor() { return _color; }
    }
}