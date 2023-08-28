namespace Game.UI
{
    using UnityEngine;
    public class ButtonMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private int _maxAmount;
        private void OnValidate()
        {
            if (_maxAmount < 0)
                _maxAmount = 0;
        }
        public GameObject[] SetButtons(int amount)
        {
            amount = Mathf.Clamp(amount, 0, _maxAmount);
            GameObject[] buttons = new GameObject[amount];
            for (int i = 0; i < amount; i++)
            {
                GameObject button = Instantiate(_buttonPrefab, transform);
                button.transform.localScale = Vector3.one;
                buttons[i] = button;
            }
            return buttons;
        }
        public void RemoveButtons()
        {
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }
    }
}