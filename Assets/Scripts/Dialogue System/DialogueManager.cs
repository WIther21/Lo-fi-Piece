namespace Game.Dialogue
{
    using TMPro;
    using UnityEngine;
    using Game.UI;
    using Game.Input;
    public class DialogueManager : MonoBehaviour
    {
        private InputManager _inputManager;
        private DialogueSO _dialogue;
        private DialogueAction[] _actions;
        private bool _isOpened;
        [Header("Message Parameters")]
        [SerializeField] private TextMeshProUGUI _actorHolder;
        [SerializeField] private ScrollText _messageHolder;
        [SerializeField] private Fade _dialogueFade;
        private int _index;
        [Header("Choice Parameters")]
        [SerializeField] private ButtonMenu _buttonMenu;
        [SerializeField] private Fade _choiceFade;
        private bool _isChoosing;
        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
        }
        public void Interact()
        {
            if (_isChoosing == true)
                return;
            if (_isOpened == false)
                StartDialogue();
            else
            {
                if (_messageHolder.IsScroll() == true)
                    _messageHolder.StopScroll();
                else if (CanUpdateMessage() == true)
                    UpdateMessage();
                else
                {
                    CloseMessageMenu();
                    if (HasChoices() == true)
                        OpenChoiceMenu();
                    else
                        StopDialogue();
                }
            }
        }
        public void SetDialogue(DialogueSO dialogue)
        {
            if (_isOpened == true)
                return;
            if (_isChoosing == true)
                return;
            _dialogue = dialogue;
        }
        public void SetActions(DialogueAction[] actions)
        {
            if (_isOpened == true)
                return;
            if (_isChoosing == true)
                return;
            _actions = actions;
        }
        private void StartDialogue()
        {
            if (HasMessages() == false && HasChoices() == false)
                return;
            _isOpened = true;
            _inputManager.SetActionMap("Dialogue");
            if (HasMessages() == true)
                OpenMessageMenu();
            else if (HasChoices() == true)
            {
                OpenChoiceMenu();
                _isChoosing = true;
            }
        }
        private void StopDialogue()
        {
            _isOpened = false;
            _inputManager.SetActionMap("Player");
            CloseMessageMenu();
        }
        private void TriggerAction(DialogueActionTrigger trigger)
        {
            if (_actions.Length == 0)
                return;
            Message[] messages = _dialogue.GetMessages();
            foreach (var action in _actions)
            {
                if (action.GetTrigger() != trigger)
                    continue;
                foreach (var message in messages)
                {
                    string key = message.GetActionKey();
                    if (key == string.Empty)
                        continue;
                    if (key == action.GetActionKey())
                        action.Action();
                }
            }
        }
        //Message Methods:
        private void OpenMessageMenu()
        {
            _dialogueFade.FadeIn();
            _index = 0;
            DisplayMessage();
            TriggerAction(DialogueActionTrigger.OnStart);
        }
        private void CloseMessageMenu()
        {
            _dialogueFade.FadeOut();
            TriggerAction(DialogueActionTrigger.OnExit);
        }
        private void DisplayMessage()
        {
            Message message = _dialogue.GetMessages()[_index];
            ActorSO actor = message.GetActor();
            Color color = actor.GetColor();

            _actorHolder.text = actor.GetName();
            _actorHolder.color = color;
            _messageHolder.Text = message.GetText();
            _messageHolder.Color = color;
            _messageHolder.Speed = message.GetSpeed();
            _messageHolder.StartScroll();
        }
        private void UpdateMessage()
        {
            _index++;
            DisplayMessage();
        }
        private bool CanUpdateMessage()
        {
            return _index != _dialogue.GetMessages().Length - 1;
        }
        private bool HasMessages() 
        {
            return _dialogue.GetMessages().Length != 0;
        }
        //Choice Methods:
        private void OpenChoiceMenu()
        {
            SetButtons();
            _choiceFade.FadeIn();
            _isChoosing = true;
        }
        private void CloseChoiceMenu()
        {
            _buttonMenu.RemoveButtons();
            _choiceFade.FadeOut();
            _isChoosing = false;
        }
        private void SetButtons()
        {
            GameObject[] buttons = _buttonMenu.SetButtons(_dialogue.GetChoices().Length);
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].GetComponent<DialogueButton>().SetButton(_dialogue.GetChoices()[i]);
        }
        public void SetChoice(int index)
        {
            if (_isOpened == false)
                return;
            if (_isChoosing == false)
                return;
            CloseChoiceMenu();
            _dialogue = _dialogue.GetChoices()[index].GetDialogue();
            OpenMessageMenu();
        }
        private bool HasChoices()
        {
            return _dialogue.GetChoices().Length != 0;
        }
    }
}