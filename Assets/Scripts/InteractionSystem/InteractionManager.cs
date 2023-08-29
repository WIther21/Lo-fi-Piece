namespace Game.Interaction
{
    using UnityEngine;
    using Game.Quest;
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] private Transform _interactionTarget;
        [SerializeField] private Vector3 _interactionOffset;
        [SerializeField] private float _interactionRadius;
        private IInteractable _currentInteractable;
        public void Interact()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_interactionTarget.position + _interactionOffset, _interactionRadius);
            if (_currentInteractable == null)
                InteractAny(colliders);
            foreach (var collider in colliders)
            {
                IInteractable interaction = collider.GetComponent<IInteractable>();
                if (interaction == null)
                    continue;
                if (interaction == _currentInteractable)
                {
                    InteractCurrent();
                    return;
                }
            }
            InteractAny(colliders);
        }
        private void InteractCurrent()
        {
            _currentInteractable.Interact();
        }
        private void InteractAny(Collider2D[] colliders)
        {
            foreach (var collider in colliders)
            {
                IInteractable interaction = collider.GetComponent<IInteractable>();
                if (interaction == null)
                    continue;
                _currentInteractable = interaction;
                interaction.Interact();
                //QuestAction action = interaction.GetComponent<QuestAction>();
                //if (action != null)
                //    action.Action();
                break;
            }
        }
        private void OnDrawGizmos()
        {
            if (_interactionTarget == null)
                return;
            Gizmos.DrawWireSphere(_interactionTarget.position + _interactionOffset, _interactionRadius);
        }
    }
}