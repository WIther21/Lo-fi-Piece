using UnityEngine;
public class DialogueObject : InteractableObject
{
    [SerializeField] private Dialogue[] _dialogues;
    private DialogueManager _manager;
    private bool _isDialogueOpen;
    private void Awake()
    {
        _manager = FindObjectOfType<DialogueManager>();
    }
    public override void Interact(PlayerInteract player)
    {
        if(_isDialogueOpen == false)
        {
            _isDialogueOpen = true;
            player.SetCrurrentInteractableObject(this);
            _manager.OpenDialogueBox(player, this);
        }
        else
        {
            _isDialogueOpen = false;
            _manager.CloseDialogueBox(player);
        }
    }
    public Dialogue GetDialogue(int index)
    {
        index = Mathf.Clamp(index, 0, _dialogues.Length - 1);
        return _dialogues[index];
    }
}