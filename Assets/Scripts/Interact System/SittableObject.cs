using UnityEngine;
using System.Collections;
public class SittableObject : InteractableObject
{
    [SerializeField] private Orientation _orientation;
    [SerializeField] private float _sitSpeed = 1f;
    private bool _isInteracting;
    private bool _canSit = true;
    private void OnValidate()
    {
        if (_sitSpeed < 0)
            _sitSpeed = 0;
    }
    public override void Interact(PlayerInteract player)
    {
        if (_canSit == false)
            return;
        if (_isInteracting == false)
            StartCoroutine(SitDown(player));
        else 
            StartCoroutine(StandUp(player));
    }
    private IEnumerator SitDown(PlayerInteract player)
    {
        _canSit = false;
        _isInteracting = true;
        player.SetCrurrentInteractableObject(this);
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SpriteRenderer>().sortingOrder = 1;
        PlayerAnimation animation = player.GetComponent<PlayerAnimation>();
        animation.SetSitting(true);
        animation.SetOrientation(_orientation);

        while (player.transform.position != transform.position)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * _sitSpeed);
            yield return null;
        }

        _canSit = true;
    }
    private IEnumerator StandUp(PlayerInteract player)
    {
        _canSit = false;

        Vector3 standUpPosition = transform.position + StandUpDirection() * 0.2f;
        while (player.transform.position != standUpPosition)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, standUpPosition, Time.deltaTime * _sitSpeed);
            yield return null;
        }

        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        player.GetComponent<PlayerAnimation>().SetSitting(false);
        player.RemoveCrurrentInteractableObject();
        _isInteracting = false;
        _canSit = true;
    }
    private Vector3 StandUpDirection()
    {
        if (_orientation == Orientation.left)
            return Vector3.left;
        else if (_orientation == Orientation.right)
            return Vector3.right;
        else if (_orientation == Orientation.lower)
            return Vector3.down;
        else
            return Vector3.up;
    }
}