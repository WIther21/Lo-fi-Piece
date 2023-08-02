using UnityEngine;
using TMPro;
public class QuestionBox : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private RectTransform _buttons;
    [SerializeField] private TextMeshProUGUI _name; 
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void OpenQuestionBox(Question[] questions)
    {
        SetButtons(questions);
        _name.text = questions[0].GetName();
        _name.color = questions[0].GetColor();
        _animator.SetBool("FadeIn", true);
    }
    public void CloseQuestionBox()
    {
        RemoveButtons();
        _animator.SetBool("FadeIn", false);
    }
    public void SetButtons(Question[] questions)
    {
        for (int i = 0; i < questions.Length; i++)
        {
            GameObject newButton = Instantiate(_buttonPrefab);
            newButton.GetComponent<RectTransform>().SetParent(_buttons);
            newButton.GetComponent<QuestionButton>().SetQuestion(questions[i]);
        }
    }
    public void RemoveButtons()
    {
        for (int i = 0; i < _buttons.childCount; i++)
        {
            Destroy(_buttons.GetChild(i).gameObject);
        }
    }
    public bool IsLoaded() { return _buttons.childCount != 0; }
}