using UnityEngine;
using TMPro;
public class QuestionButton : MonoBehaviour
{
    private Question _question;
    private DialogueManager _dialogueManager;
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void LoadQuestion()
    {
        _dialogueManager.LoadDialogues(_question.GetDialogues());
        if (_question.IsExitQuestion())
            _dialogueManager.CanExit = true;
    }
    public void SetQuestion(Question question)
    {
        _question = question;
        _text.text = question.GetText();
        _text.color = question.GetColor();
    }
}