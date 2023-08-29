namespace Game.Interaction
{
    using UnityEngine;
    using Game.UI;
    public class EntranceDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _sceneName;
        private SceneChanger _changer;
        private void Awake()
        {
            _changer = FindObjectOfType<SceneChanger>();
        }
        public void Interact()
        {
            _changer.Fade(_sceneName);
        }
    }
}