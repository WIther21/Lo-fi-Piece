using UnityEngine;
[System.Serializable]
public struct Question
{
    [SerializeField] private string _name;
    [SerializeField] private string _text;
    [SerializeField] private Color _color;
    [SerializeField] private Dialogue[] _dialogues;
    [SerializeField] private bool _isExitQuestion;
    public string GetName() { return _name; }
    public string GetText() { return _text; }
    public Color GetColor() { return _color; }
    public Dialogue[] GetDialogues() {  return _dialogues; }
    public bool IsExitQuestion() { return _isExitQuestion; }
}