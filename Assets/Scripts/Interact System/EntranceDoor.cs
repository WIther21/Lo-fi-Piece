using UnityEngine;
using UnityEngine.SceneManagement;
public class EntranceDoor : InteractableObject
{
    [SerializeField] private string _sceneName;
    private SceneFader _fader;
    private void Awake()
    {
        _fader = FindObjectOfType<SceneFader>();
    }
    public override void Interact(PlayerInteract player)
    {
        if (_fader == null)
            return;
        LoadScene();
    }
    private void LoadScene()
    {
        _fader.FadeOut(_sceneName);
    }
}