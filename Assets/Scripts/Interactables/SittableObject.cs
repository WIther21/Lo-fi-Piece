using UnityEngine;
public class SittableObject : InteractableObject
{
    private enum Orientation { left, right, lower, upper }
    [SerializeField] private Orientation _orientation;
    private bool _isSitting;
    public override void Interact(PlayerInteract player)
    {
        if (_isSitting == false)
            SitDown(player);
        else 
            StandUp(player);
    }
    private void SitDown(PlayerInteract player)
    {
        _isSitting = true;
        player.SetCrurrentInteractableObject(this);
        player.transform.position = transform.position;
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SpriteRenderer>().sortingOrder = 1;

        PlayerAnimation animation = player.GetComponent<PlayerAnimation>();
        animation.SetSitting(true);
        CheckLayer(animation);
    }
    private void StandUp(PlayerInteract player)
    {
        _isSitting = false;
        player.transform.position = transform.position + StandUpDirection() * 0.2f;
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        player.GetComponent<PlayerAnimation>().SetSitting(false);
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
    private void CheckLayer(PlayerAnimation animation)
    {
        if (_orientation == Orientation.left)
        {
            animation.SetLayer(0);
            if (animation.transform.localScale.x > 0)
                animation.Flip();
        }
        else if (_orientation == Orientation.right)
        {
            animation.SetLayer(0);
            if (animation.transform.localScale.x < 0)
                animation.Flip();
        }
        else if (_orientation == Orientation.lower)
        {
            animation.SetLayer(1);
        }
        else
        {
            animation.SetLayer(2);
        }
    }
}