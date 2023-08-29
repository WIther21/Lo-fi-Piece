namespace Game.Interaction
{
    using UnityEngine;
    public class InteractionController : MonoBehaviour
    {
        private InteractionManager _manager;
        private void Awake()
        {
            _manager = FindObjectOfType<InteractionManager>();
        }
        private void OnInteract()
        {
            _manager.Interact();
        }
    }
}