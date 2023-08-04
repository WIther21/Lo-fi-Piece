namespace Game.Interact
{
    using UnityEngine;
    using Game.Base;
    public class EntranceDoor : InteractableObject
    {
        [SerializeField] private string _sceneName;
        private SceneChanger _fader;
        private void Awake()
        {
            _fader = FindObjectOfType<SceneChanger>();
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
}