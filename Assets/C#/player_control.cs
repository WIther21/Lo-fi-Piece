using UnityEngine;

public class player_control : MonoBehaviour
{
  [SerializeField] private float _speed;
  private Rigidbody2D _rb;
  private Animator _anim;
  private Vector2 _direction;
  private bool _is_sitting;
  
  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    _anim = GetComponent<Animator>();
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

  public void Sit()
  {
    ResetAnimations();
    _is_sitting = !_is_sitting;
  }

}
