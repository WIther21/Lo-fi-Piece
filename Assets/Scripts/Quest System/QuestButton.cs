namespace Game.Quest
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    public class QuestButton : MonoBehaviour
    {
        private QuestManager _questManager;
        private TextMeshProUGUI _textHolder;
        private void Awake()
        {
            _questManager = FindObjectOfType<QuestManager>();
            _textHolder = GetComponentInChildren<TextMeshProUGUI>();
        }
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(LoadQuest);
        }
        public void SetButton(QuestSO quest)
        {
            _textHolder.text = quest.GetTitle();
        }
        private void LoadQuest()
        {
            _questManager.LoadQuest(transform.GetSiblingIndex());
        }
    }
}