using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueName;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private FadeAnimation _fadeAnimation;
    public void OpenDialogueBox(PlayerInteract player, DialogueObject dialogue)
    {
        _fadeAnimation.FadeIn();
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerAnimation>().enabled = false;

        _dialogueName.text = dialogue.GetDialogue(0).GetDialogueName();
        _dialogueText.text = dialogue.GetDialogue(0).GetDialogueText();
        Color dialogueColor = dialogue.GetDialogue(0).GetDialogueColor();
        _dialogueName.color = dialogueColor;
        _dialogueText.color = dialogueColor;
    }
    public void CloseDialogueBox(PlayerInteract player)
    {
        _fadeAnimation.FadeOut();
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerAnimation>().enabled = true;
    }
}