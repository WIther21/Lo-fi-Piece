namespace Game.UI
{
    using UnityEngine;
    public class FadeManager : MonoBehaviour
    {
        [SerializeField] private FadeButton[] _buttons;
        [SerializeField] private Color _unselected;
        [SerializeField] private Color _selected;
        private FadeButton _currentButton;
        private void Start()
        {
            _currentButton = _buttons[0];
            Open();
        }
        public void SetButton(int index)
        {
            Close();
            _currentButton = _buttons[index];
            Open();
        }
        public void Open()
        {
            _currentButton.GetFade().FadeIn();
            _currentButton.GetImage().color = _selected;
        }
        public void Close()
        {
            _currentButton.GetFade().FadeOut();
            _currentButton.GetImage().color = _unselected;
        }
    }
}