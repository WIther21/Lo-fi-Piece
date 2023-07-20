using UnityEngine;
[RequireComponent (typeof(PlayerInputReader))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private void OnDisable()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}