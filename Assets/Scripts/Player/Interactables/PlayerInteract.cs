using UnityEngine;
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _interactionRadius;
    public void Interact()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _interactionRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            InteractableObject interaction = colliders[i].GetComponent<InteractableObject>();
            if(interaction != null)
            {
                interaction.Interact(gameObject);
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactionRadius);
    }
}