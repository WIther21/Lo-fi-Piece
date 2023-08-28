namespace Game.Dialogue
{
    using UnityEngine;
    using Game.Interact;
    public class DialogueTrigger : InteractableObject
    {
        [SerializeField] private DialogueSO _dialogue;
        private DialogueManager _dialogueManager;
        private DialogueAction[] _dialogueActions;
        private void Awake()
        {
            _dialogueManager = FindObjectOfType<DialogueManager>();
            _dialogueActions = GetComponents<DialogueAction>();
        }
        public override void Interact(PlayerInteract playerInteract)
        {
            _dialogueManager.SetDialogue(_dialogue);
            _dialogueManager.SetActions(_dialogueActions);
            _dialogueManager.Interact();
        }
    }
}