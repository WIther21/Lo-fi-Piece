using UnityEngine;
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _direction;
    private bool _isSitting;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SetParameters();
        if (_isSitting == false)
        {
            ChangeLayer();
            if (ChangeDirection())
                Flip();
        }
    }
    private void SetParameters()
    {
        if (_isSitting == false)
        {
            if (_direction.x != 0 || _direction.y != 0)
                _animator.SetBool("IsMoving", true);
            else
                _animator.SetBool("IsMoving", false);

            _animator.SetBool("IsSitting", false);
        }
        else
            _animator.SetBool("IsSitting", true);
    }
    private void ChangeLayer()
    {
        if (_direction.y == 0)
        {
            if (_direction.x != 0)
                SetLayer(0);
        }
        else
        {
            if (_direction.y < 0)
                SetLayer(1);
            else if (_direction.y > 0)
                SetLayer(2);
        }
    }
    private bool ChangeDirection()
    {
        if (_direction.x > 0 && transform.localScale.x < 0 && _direction.y == 0 ||
            _direction.x < 0 && transform.localScale.x > 0 && _direction.y == 0)
            return true;
        else
            return false;
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    public void SetLayer(int index)
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
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    public void SetSitting(bool value)
    {
        _isSitting = value;
    }
}