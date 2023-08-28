namespace Game.Interact
{
    using UnityEngine;
    using Game.UI;
    public class EntranceDoor : InteractableObject
    {
        [SerializeField] private string _sceneName;
        private SceneChanger _changer;
        private void Awake()
        {
            _changer = FindObjectOfType<SceneChanger>();
        }
        public override void Interact(PlayerInteract player)
        {
            _changer.Fade(_sceneName);
        }
    }
}