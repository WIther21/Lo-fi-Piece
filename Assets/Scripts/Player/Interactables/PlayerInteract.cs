using UnityEngine;
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _interactionRadius;
    private InteractableObject _currentObject;
    public virtual void Interact()
    {
        if (_currentObject)
        {
            _currentObject.Interact(gameObject);
            _currentObject = null;
        }
        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _interactionRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                InteractableObject interaction = colliders[i].GetComponent<InteractableObject>();
                if (interaction != null)
                {
                    interaction.Interact(gameObject);
                    break;
                }
            }
        }
    }
    public void SetCrurrentInteractableObject(InteractableObject interact)
    {
        _currentObject = interact;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactionRadius);
    }
}