using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public enum Orientation { left, right, lower, upper }
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetMoving(bool value)
    {
        _animator.SetBool("IsMoving", value);
    }
    public void SetSitting(bool value)
    {
        _animator.SetBool("IsSitting", value);
    }
    public void SetOrientation(Orientation orientation)
    {
        if (orientation == Orientation.left)
        {
            SetLayer(0);
            if (transform.localScale.x > 0)
                Flip();
        }
        else if (orientation == Orientation.right)
        {
            SetLayer(0);
            if (transform.localScale.x < 0)
                Flip();
        }
        else if (orientation == Orientation.lower)
        {
            SetLayer(1);
        }
        else
        {
            SetLayer(2);
        }
    }
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void SetLayer(int index)
    {
        index = Mathf.Clamp(index + 1, 0, _animator.layerCount - 1);
        for (int i = 0; i < _animator.layerCount; i++)
        {
            if (i == index)
                _animator.SetLayerWeight(i, 1);
            else
                _animator.SetLayerWeight(i, 0);
        }
    }
}