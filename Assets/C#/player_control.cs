using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class player_control : MonoBehaviour
{
  private Rigidbody2D _rb;
  private Vector2 _direction;
  private Animator _anim;
  private bool _is_sitting;
  private bool _in_moved;

  [SerializeField] private float _multiplier;
  [SerializeField] private float _min_speed;
  private float _max_speed;
  private float _speed;
  private float _acceleration;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    _anim = GetComponent<Animator>();
  }

  private void Start()
  {
    _acceleration = _min_speed;
    _speed = _min_speed;
    _max_speed = _speed * _multiplier;
  }

  private void Update()
  {
    if (_is_sitting)
      StopPlayer();
    else
      SetDirection();
    SetAnimations();
    if (ChangeDirection())
      Flip();
  }

  private void FixedUpdate()
  {
    if (_direction != Vector2.zero && !_in_moved && !_is_sitting)
    {
      _speed = _min_speed;
      StartCoroutine(AccelMove());
      _in_moved = true;
    }
    MovePlayer();
  }

  private void SetDirection()
  {
    float inputH = Input.GetAxisRaw("Horizontal");
    float inputV = Input.GetAxisRaw("Vertical");

    if (inputH != 0)
    {
      if (inputV == 0)
        _direction = new Vector2(inputH, 0);
    }
    else if (inputV != 0)
      _direction = new Vector2(0, inputV);
    else
      StopPlayer();
  }

  private bool ChangeDirection()
  {
    if (transform.localScale.x > 0 && _direction.x < 0 || transform.localScale.x < 0 && _direction.x > 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  private void SetAnimations()
  {
    _anim.SetInteger("DirectionX", Mathf.RoundToInt(_direction.x));
    _anim.SetInteger("DirectionY", Mathf.RoundToInt(_direction.y));
    _anim.SetBool("isSitting", _is_sitting);
  }

  private void ResetAnimations()
  {
    _anim.SetInteger("DirectionX", 0);
    _anim.SetInteger("DirectionY", 0);
    _anim.SetBool("isSitting", false);
  }

  private void Flip()
  {
    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
  }

  private void StopPlayer()
  {
    _direction = Vector2.zero;
  }

  private void MovePlayer()
  {
    _rb.velocity = _direction * _speed;
  }

  private IEnumerator AccelMove()
  {
    while (_speed <= _max_speed)
    {
      yield return new WaitForSeconds(0.15f);
      _speed += _acceleration;
    }
    if (_speed > _max_speed)
    {
      _speed = _max_speed;
    }
    if(_direction == Vector2.zero)
    {
      _speed = 0;
      _in_moved = false;
    }
  }

  public void Sit()
  {
    ResetAnimations();
    _is_sitting = !_is_sitting;
  }

}
