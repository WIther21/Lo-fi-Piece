using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class EntranceDoor : InteractableObject
{
    [SerializeField] private string _sceneName;
    [SerializeField] private FadeAnimation _fadeAnimation;
    public override void Interact(GameObject player)
    {
        StartCoroutine(WaitForFade());
    }
    private IEnumerator WaitForFade()
    {
        _fadeAnimation.ChangeFadeValue(1f);
        yield return new WaitForSeconds(_fadeAnimation.GetDelay());
        do
        {
            yield return null;
        } while (_fadeAnimation.IsCompleted() == false);
        SceneManager.LoadScene(_sceneName);
    }
}