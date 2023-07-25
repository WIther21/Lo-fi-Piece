using UnityEngine;
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Vector3 _interactionOffset;
    [SerializeField] private float _interactionRadius;
    private InteractableObject _currentObject;
    public virtual void Interact()
    {
        if (_currentObject)
            InteractCurrent();
        else
            InteractAny();
    }
    public void SetCrurrentInteractableObject(InteractableObject interact)
    {
        _currentObject = interact;
    }
    private void InteractCurrent()
    {
        _currentObject.Interact(this);
        _currentObject = null;
    }
    private void InteractAny()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + _interactionOffset, _interactionRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            InteractableObject interaction = colliders[i].GetComponent<InteractableObject>();
            if (interaction != null)
            {
                interaction.Interact(this);
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + _interactionOffset, _interactionRadius);
    }
}