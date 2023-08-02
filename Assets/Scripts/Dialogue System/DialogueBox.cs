using TMPro;
using UnityEngine;
public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _text;
    private Animator _animator;
    private Dialogue[] _dialogues;
    private int _index;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void OpenDialogueBox(Dialogue[] dialogues)
    {
        _dialogues = dialogues;
        _index = 0;
        SetDialogue(_dialogues[_index]);
        _animator.SetBool("FadeIn", true);
    }
    public void CloseDialogueBox()
    {
        _animator.SetBool("FadeIn", false);
    }
    public void UpdateDialogue()
    {
        _index++;
        SetDialogue(_dialogues[_index]);
    }
    public bool CanUpdateDialogue() { return _index != _dialogues.Length - 1; }
    private void SetDialogue(Dialogue dialogue)
    {
        Color color = dialogue.GetColor();
        _name.color = color;
        _text.color = color;

        _name.text = dialogue.GetName();
        _text.text = dialogue.GetText();
    }
}