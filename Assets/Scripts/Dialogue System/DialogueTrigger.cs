namespace Game.Dialogue
{
    using UnityEngine;
    using Game.Player;
    using Game.Interact;
    public class DialogueTrigger : InteractableObject
    {
        [SerializeField] private Dialogue[] _dialogues;
        [SerializeField] private Question[] _questions;
        private DialogueBox _dialogueBox;
        private QuestionBox _questionBox;
        private PlayerMovement _playerMovement;
        private bool _isInteracting;
        private void Awake()
        {
            _dialogueBox = FindObjectOfType<DialogueBox>();
            _questionBox = FindObjectOfType<QuestionBox>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }
        public override void Interact(PlayerInteract player)
        {
            if (_isInteracting == false)
            {
                if (_dialogues.Length != 0)
                {
                    OpenDialogie(player);
                    _dialogueBox.OpenBox(_dialogues);
                }
                else if (_questions.Length != 0)
                {
                    if (_questions[0].GetDialogues().Length == 0)
                        return;
                    OpenDialogie(player);
                    _questionBox.OpenBox(_questions);
                }
            }
            else
            {
                if (_dialogueBox.CanUpdateDialogue())
                    _dialogueBox.UpdateBox();
                else if (_questions.Length != 0)
                {
                    if (_dialogueBox.CanExit())
                        CloseDialogue(player);
                    else
                    {
                        _dialogueBox.CloseBox();
                        _questionBox.OpenBox(_questions);
                    }
                }
                else
                    CloseDialogue(player);
            }
        }
        private void OpenDialogie(PlayerInteract player)
        {
            _isInteracting = true;
            player.SetCrurrentInteractableObject(this);
            _playerMovement.enabled = false;
        }
        private void CloseDialogue(PlayerInteract player)
        {
            _isInteracting = false;
            player.RemoveCrurrentInteractableObject();
            _playerMovement.enabled = true;
            _dialogueBox.CloseBox();
            _questionBox.CloseBox();
        }
    }
}