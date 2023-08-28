namespace Game.Quest
{
    using UnityEngine;
    public abstract class QuestAction : MonoBehaviour
    {
        [SerializeField] private string _actionKey;
        private QuestManager _questManager;
        private bool _isActive = true;
        public string GetKey() { return _actionKey; }
        private void Awake()
        {
            _questManager = FindObjectOfType<QuestManager>();
        }
        public abstract void Action();
        protected void IncreaseAmount()
        {
            if (_isActive == false)
                return;
            _isActive = !_questManager.TriggerAction(_actionKey);
        }
    }
}