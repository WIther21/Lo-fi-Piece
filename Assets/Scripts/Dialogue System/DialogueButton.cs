namespace Game.Dialogue
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    public class DialogueButton : MonoBehaviour
    {
        private DialogueManager _dialogueManager;
        [SerializeField] private TextMeshProUGUI _textHolder;
        private void Awake()
        {
            _dialogueManager = FindObjectOfType<DialogueManager>();
        }
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(LoadDialogue);
        }
        public void SetButton(Choice choice)
        {
            _textHolder.text = choice.GetText();
            _textHolder.color = choice.GetColor();
        }
        public void LoadDialogue()
        {
            _dialogueManager.SetChoice(transform.GetSiblingIndex());
        }
    }
}