using UnityEngine;
public class DialogueTrigger : InteractableObject
{
    [SerializeField] private Dialogue[] _dialogues;
    [SerializeField] private Question[] _questions;
    private DialogueManager _dialogueManager;
    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public override void Interact(PlayerInteract player)
    {
        if (_dialogueManager.CanExit)
            _dialogueManager.StopDialogue();
        else
        {
            if (_dialogueManager.IsDialogueTrigger())
            {
                if (_dialogueManager.CanUpdateDialogue())
                    _dialogueManager.UpdateDialogue();
                else if (_dialogueManager.IsQuestionsLoaded() == false)
                    _dialogueManager.LoadQuestions();
            }
            else
                _dialogueManager.StartDialogue(this);
        }
    }
    public Dialogue[] GetDialogues() { return _dialogues; }
    public Question[] GetQuestions() { return _questions; }
}