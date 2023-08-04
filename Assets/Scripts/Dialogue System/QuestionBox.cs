namespace Game.Dialogue
{
    using UnityEngine;
    public class QuestionBox : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private RectTransform _buttons;
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void OpenBox(Question[] questions)
        {
            RemoveButtons();
            SetButtons(questions);
            _animator.SetBool("FadeIn", true);
        }
        public void CloseBox()
        {
            _animator.SetBool("FadeIn", false);
        }
        private void SetButtons(Question[] questions)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                GameObject newButton = Instantiate(_buttonPrefab);
                newButton.GetComponent<RectTransform>().SetParent(_buttons);
                newButton.GetComponent<QuestionButton>().SetQuestion(questions[i]);
            }
        }
        private void RemoveButtons()
        {
            for (int i = 0; i < _buttons.childCount; i++)
            {
                Destroy(_buttons.GetChild(i).gameObject);
            }
        }
    }
}