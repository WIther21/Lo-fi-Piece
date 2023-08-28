namespace Game.Quest
{
    using UnityEngine;
    using TMPro;
    using System.Collections.Generic;
    using Game.UI;
    using Game.Player;
    public class QuestManager : MonoBehaviour
    {
        [Header("Quest Parameters")]
        [SerializeField] private ButtonMenu _questNavigation;
        [SerializeField] private TextMeshProUGUI _titleHolder;
        [SerializeField] private TextMeshProUGUI _descriptionHolder;
        [SerializeField] private SliderController _sliderController;
        private List<QuestSO> _quests = new List<QuestSO>();
        private PlayerController _playerController;
        private QuestSO _currentQuest;
        [Header("Goal Parameters")]
        [SerializeField] private TextMeshProUGUI _goalTitleHolder;
        [SerializeField] private ButtonMenu _goalButtons;
        private Dictionary<QuestSO, List<GoalTracker>> _goalTrackers = new Dictionary<QuestSO, List<GoalTracker>>();
        [Header("Reward Parameters")]
        [SerializeField] private TextMeshProUGUI _rewardTitleHolder;
        [SerializeField] private ButtonMenu _rewardButtons;
        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }
        public void LoadButtons()
        {
            _sliderController.CheckRectSize();
            _questNavigation.RemoveButtons();
            RemoveQuestMenu();
            if (_quests.Count != 0)
            {
                if (_currentQuest == null)
                    _currentQuest = _quests[0];
                SetButtons();
                SetQuestMenu();
            }
        }
        public bool TriggerAction(string actionKey)
        {
            if (_quests.Count == 0)
                return false;
            bool isExit = false;
            for (int i = 0; i < _quests.Count; i++)
            {
                foreach (var tracker in _goalTrackers[_quests[i]])
                {
                    string[] keys = tracker.GetGoal().GetKeys();
                    foreach (var key in keys)
                    {
                        if (key == string.Empty)
                            continue;
                        if (key != actionKey)
                            continue;
                        tracker.IncreaseAmount();
                        isExit = true;
                    }
                }
                if (IsCompleted(_quests[i]) == true)
                    RemoveQuest(_quests[i]);
            }
            return isExit;
        }
        public void AddQuest(QuestSO quest)
        {
            if (_quests.Contains(quest))
                return;
            _quests.Add(quest);
            AddGoalTrackers(quest);
            LoadButtons();
        }
        private void RemoveQuest(QuestSO quest)
        {
            _quests.Remove(quest);
            RemoveGoalTrackers(quest);
            Reward[] rewards = quest.GetRewards();
            foreach (var reward in rewards)
                _playerController.AddMoney(reward.GetAmount());
            _currentQuest = null;
            LoadButtons();
        }
        public void LoadQuest(int index)
        {
            if (_currentQuest == _quests[index])
                return;
            RemoveQuestMenu();
            _currentQuest = _quests[index];
            SetQuestMenu();
        }
        private void SetQuestMenu()
        {
            _titleHolder.text = _currentQuest.GetTitle();
            _descriptionHolder.text = _currentQuest.GetDescription();
            _goalTitleHolder.text = "ÖÅËÈ:";
            _rewardTitleHolder.text = "ÍÀÃÐÀÄÛ:";
            SetGoals();
            SetRewards();
        }
        private void RemoveQuestMenu()
        {
            _titleHolder.text = "ÍÅÒ ÄÎÑÒÓÏÍÛÕ ÇÀÄÀÍÈÉ";
            _descriptionHolder.text = string.Empty;
            _goalTitleHolder.text = string.Empty;
            _rewardTitleHolder.text = string.Empty;
            _goalButtons.RemoveButtons();
            _rewardButtons.RemoveButtons();
        }
        private bool IsCompleted(QuestSO quest)
        {
            foreach (var tracker in _goalTrackers[quest])
            {
                if (tracker.IsReached())
                    continue;
                else
                    return false;
            }
            return true;
        }
        private void AddGoalTrackers(QuestSO quest)
        {
            Goal[] goals = quest.GetGoals();
            List<GoalTracker> trackers = new List<GoalTracker>(goals.Length);
            foreach (var goal in goals)
            {
                GoalTracker tracker = new GoalTracker(goal);
                trackers.Add(tracker);
            }
            _goalTrackers.Add(quest, trackers);
        }
        private void RemoveGoalTrackers(QuestSO quest)
        {
            for (int i = 0; i < _goalTrackers[quest].Count; i++)
                _goalTrackers[quest].RemoveAt(i);
        }
        //Button Methods
        private void SetButtons()
        {
            GameObject[] buttons = _questNavigation.SetButtons(_quests.Count);
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].GetComponent<QuestButton>().SetButton(_quests[i]);
        }
        private void SetGoals()
        {
            GameObject[] goalButtons = _goalButtons.SetButtons(_goalTrackers[_currentQuest].Count);
            for (int i = 0; i < goalButtons.Length; i++)
                goalButtons[i].GetComponent<GoalButton>().SetButton(_goalTrackers[_currentQuest][i]);
        }
        private void SetRewards()
        {
            GameObject[] rewards = _rewardButtons.SetButtons(_currentQuest.GetRewards().Length);
            for (int i = 0; i < rewards.Length; i++)
                rewards[i].GetComponent<RewardButton>().SetButton(_currentQuest.GetRewards()[i]);
        }
    }
}