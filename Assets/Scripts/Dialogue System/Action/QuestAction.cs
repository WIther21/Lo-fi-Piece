namespace Game.Dialogue
{
    using UnityEngine;
    using Game.Quest;
    public class QuestAction : DialogueAction
    {
        [SerializeField] private QuestSO _quest;
        private QuestManager _questManager;
        private void Awake()
        {
            _questManager = FindObjectOfType<QuestManager>();
        }
        public override void Action()
        {
            if (_isDisabled == true)
                return;
            _isDisabled = true;
            _questManager.AddQuest(_quest);
        }
    }
}