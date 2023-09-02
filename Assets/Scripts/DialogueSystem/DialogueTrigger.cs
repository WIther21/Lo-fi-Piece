namespace Game.Dialogue
{
    using UnityEngine;
    using Game.Interaction;
    public class DialogueTrigger : MonoBehaviour, IInteractable
    {
        [SerializeField] private DialogueSO _dialogue;
        private DialogueManager _dialogueManager;
        private DialogueAction[] _dialogueActions;
        private void Awake()
        {
            _dialogueManager = FindObjectOfType<DialogueManager>();
            _dialogueActions = GetComponents<DialogueAction>();
        }
        public void Interact()
        {
            _dialogueManager.SetDialogue(_dialogue);
            _dialogueManager.SetActions(_dialogueActions);
            _dialogueManager.Interact();
        }
    }
}