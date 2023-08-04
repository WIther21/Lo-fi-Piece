namespace Game.Dialogue
{
    using UnityEngine;
    [System.Serializable]
    public struct Question
    {
        [SerializeField] private string _text;
        [SerializeField] private Color _color;
        [SerializeField] private Dialogue[] _dialogues;
        [SerializeField] private QuestionType _questionType;
        public string GetText() { return _text; }
        public Color GetColor() { return _color; }
        public Dialogue[] GetDialogues() { return _dialogues; }
        public QuestionType GetQuestionType() { return _questionType; }
    }
    public enum QuestionType { Exit, Empty, Quest }
}