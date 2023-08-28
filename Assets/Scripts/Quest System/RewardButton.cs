namespace Game.Quest
{
    using UnityEngine;
    using TMPro;
    public class RewardButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amountHolder;
        public void SetButton(Reward reward)
        {
            _amountHolder.text = reward.GetAmount().ToString();
        }
    }
}