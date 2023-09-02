namespace Game.Dialogue
{
    using Game.Inventory;
    using Game.UI;
    using UnityEngine;
    public class DialogueController : MonoBehaviour
    {
        private DialogueManager _dialogueManager;
        private void Awake()
        {
            _dialogueManager = FindObjectOfType<DialogueManager>();
        }
        private void OnDialogue()
        {
            _dialogueManager.Interact();
        }
    }
}