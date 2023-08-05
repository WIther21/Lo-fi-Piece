namespace Game.Dialogue
{
    using UnityEngine;
    using System.Collections;
    using TMPro;
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _text;
        private Animator _animator;
        private Dialogue[] _dialogues;
        private int _index;
        private bool _canExit;
        private Coroutine _scrollingCoroutine;
        private string _currentText;
        private bool _isScrolling;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void OpenBox(Dialogue[] dialogues)
        {
            _dialogues = dialogues;
            _index = 0;
            _scrollingCoroutine = StartCoroutine(SetDialogue(_dialogues[_index]));
            _animator.SetBool("FadeIn", true);
        }
        public void CloseBox()
        {
            _animator.SetBool("FadeIn", false);
            _canExit = false;
        }
        public void UpdateBox()
        {
            if (_isScrolling)
            {
                StopCoroutine(_scrollingCoroutine);
                _text.text = _currentText;
                _isScrolling = false;
            }
            else
            {
                _index++;
                _scrollingCoroutine = StartCoroutine(SetDialogue(_dialogues[_index]));
            }
        }
        public bool CanExit() { return _canExit; }
        public void SetExit() { _canExit = true; }
        public bool CanUpdateDialogue()
        {
            if (_dialogues == null)
                return false;
            if(_dialogues.Length == 0)
                return false;
            return _index != _dialogues.Length - 1 || _isScrolling;
        }
        private IEnumerator SetDialogue(Dialogue dialogue)
        {
            _isScrolling = true;
            Color color = dialogue.GetColor();
            _name.color = color;
            _text.color = color;

            _name.text = dialogue.GetName();
            _currentText = dialogue.GetText();
            float speed = dialogue.GetSpeed();
            for (int i = 0; i < _currentText.Length + 1; i++)
            {
                _text.text = _currentText.Substring(0, i);
                yield return new WaitForSeconds(0.1f / speed);
            }
            _isScrolling = false;
        }
    }
}