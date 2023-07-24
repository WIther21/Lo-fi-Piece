using UnityEngine;
[System.Serializable]
public class Dialogue
{
    [TextArea(1, 1)] [SerializeField] private string _dialogueName;
    [TextArea(2, 4)] [SerializeField] private string _dialogueText;
    [SerializeField] private Color _textColor;
    public string GetDialogueName() { return _dialogueName; }
    public string GetDialogueText() { return _dialogueText; }
    public Color GetDialogueColor() { return _textColor; }
}