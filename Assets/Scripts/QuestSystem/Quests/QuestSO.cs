namespace Game.Quest
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Quest", menuName = "Game/Quest")]
    public class QuestSO : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] [TextArea(1, 3)] private string _description;
        [SerializeField] private Goal[] _goals;
        [SerializeField] private Reward[] _rewards;
        public string GetTitle() { return _title; }
        public string GetDescription() { return _description; }
        public Goal[] GetGoals() { return _goals; }
        public Reward[] GetRewards() { return _rewards; }
    }
}