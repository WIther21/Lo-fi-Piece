using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private DialogueTrigger _dialogueTrigger;
    private DialogueBox _dialogueBox;
    private QuestionBox _questionBox;
    public bool CanExit;
    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _dialogueBox = GetComponentInChildren<DialogueBox>();
        _questionBox = GetComponentInChildren<QuestionBox>();
    }
    public void StartDialogue(DialogueTrigger trigger)
    {
        _playerMovement.enabled = false;
        _dialogueTrigger = trigger;
        LoadDialogues(_dialogueTrigger.GetDialogues());
    }
    public void StopDialogue()
    {
        _playerMovement.enabled = true;
        _dialogueTrigger = null;
        _dialogueBox.CloseDialogueBox();
        _questionBox.CloseQuestionBox();
        CanExit = false;
    }
    public void LoadQuestions()
    {
        _dialogueBox.CloseDialogueBox();
        _questionBox.OpenQuestionBox(_dialogueTrigger.GetQuestions());
    }    
    public void LoadDialogues(Dialogue[] dialogues)
    {
        _questionBox.CloseQuestionBox();
        _dialogueBox.OpenDialogueBox(dialogues);
    }
    public void UpdateDialogue() { _dialogueBox.UpdateDialogue(); }
    public bool IsDialogueTrigger() { return _dialogueTrigger; }
    public bool IsQuestionsLoaded() { return _questionBox.IsLoaded(); }
    public bool CanUpdateDialogue() { return _dialogueBox.CanUpdateDialogue(); }
}