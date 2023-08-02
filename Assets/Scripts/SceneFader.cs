using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    private Animator _animator;
    private PlayerInputReader _inputReader;
    private string _sceneName;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputReader = FindObjectOfType<PlayerInputReader>();
    }
    private void Start()
    {
        _inputReader.SetActive(false);
    }
    public void FadeOut(string sceneName)
    {
        _sceneName = sceneName;
        _inputReader.SetActive(false);
        _animator.SetTrigger("FadeOut");
    }
    private void OnFadeOut()
    {
        SceneManager.LoadScene(_sceneName);
    }
    private void OnFadeIn()
    {
        _inputReader.SetActive(true);
    }
}