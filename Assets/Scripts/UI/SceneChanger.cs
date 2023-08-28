namespace Game.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Game.Input;
    public class SceneChanger : MonoBehaviour
    {
        private InputManager _inputManager;
        private Animator _animator;
        private string _sceneName;
        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
            _animator = GetComponent<Animator>();
        }
        public void Fade(string sceneName)
        {
            _inputManager.SetActionMap("None");
            _animator.SetTrigger("Fade");
            _sceneName = sceneName;
        }
        private void OnFadeIn()
        {
            SceneManager.LoadScene(_sceneName);
        }   
        private void OnFadeOut()
        {
            _inputManager.SetActionMap("Player");
        }
    }
}