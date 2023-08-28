namespace Game.Quest
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    public class GoalButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHolder;
        [SerializeField] private TextMeshProUGUI _currentAmountHolder;
        [SerializeField] private TextMeshProUGUI _requiredAmountHolder;
        [SerializeField] private Image _checkMark;
        public void SetButton(GoalTracker tracker)
        {
            _textHolder.text = tracker.GetGoal().GetText();
            _currentAmountHolder.text = tracker.GetCurrentAmount().ToString();
            _requiredAmountHolder.text = tracker.GetGoal().GetRequiredAmount().ToString();
            if (tracker.IsReached())
                _checkMark.enabled = true;
        }
    }
}