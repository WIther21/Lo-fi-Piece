namespace Game.Interact
{
    using UnityEngine;
    public abstract class InteractableObject : MonoBehaviour
    {
        public abstract void Interact(PlayerInteract player);
    }
}