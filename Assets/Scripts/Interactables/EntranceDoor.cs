using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class EntranceDoor : InteractableObject
{
    [SerializeField] private string _sceneName;
    [SerializeField] private FadeAnimation _fadeAnimation;
    public override void Interact(PlayerInteract player)
    {
        if (_fadeAnimation == null)
            return;
        StartCoroutine(WaitForFade());
    }
    private IEnumerator WaitForFade()
    {
        _fadeAnimation.FadeIn();
        do
        {
            yield return null;
        } while (_fadeAnimation.GetCompleted() == false);
        SceneManager.LoadScene(_sceneName);
    }
}