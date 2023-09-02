using UnityEngine;

namespace Game.Dialogue
{
    public abstract class DialogueAction : MonoBehaviour
    {
        [SerializeField] private string _actionKey;
        [SerializeField] private DialogueActionTrigger _trigger;
        protected bool _isDisabled;
        public string GetActionKey() { return _actionKey; }
        public DialogueActionTrigger GetTrigger() { return _trigger; }
        public abstract void Action();
    }
    public enum DialogueActionTrigger { OnStart, OnExit }
}