namespace Game.Dialogue
{
    using UnityEngine;
    using TMPro;
    public class QuestionButton : MonoBehaviour
    {
        private DialogueBox _dialogueBox;
        private QuestionBox _questionBox;
        private TextMeshProUGUI _text;
        private Question _question;
        private void Awake()
        {
            _dialogueBox = FindObjectOfType<DialogueBox>();
            _questionBox = FindObjectOfType<QuestionBox>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }
        public void LoadQuestion()
        {
            _questionBox.CloseBox();
            _dialogueBox.OpenBox(_question.GetDialogues());
            if (_question.GetQuestionType() == QuestionType.Exit)
                _dialogueBox.SetExit();
        }
        public void SetQuestion(Question question)
        {
            _question = question;
            _text.text = question.GetText();
            _text.color = question.GetColor();
        }
    }
}