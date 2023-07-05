using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_mover : MonoBehaviour
{
  private InputSystem _input;
  private Vector2 _direction;
  private Animator anim;
  private float _speed;
  private float _max_speed;
  private float _min_speed;
  private float _acceleration;
  private Rigidbody2D _rb;

  private void Awake()
  {
    _input = new InputSystem();
    _rb = GetComponent<Rigidbody2D>();
  }

  private states state
  {
    get { return (states) anim.GetInteger("state"); }
    set { anim.SetInteger("state", (int)value); }
  }

  private void OnEnable()
  {
    _input.Enable();
  }

  private void OnDisable()
  {
    _input.Disable();
  }

  private void Start()
  {
    _min_speed = 0.4f;
    _acceleration = _min_speed;
    _speed = _min_speed;
    _max_speed = _speed * 3;
    anim = GetComponent<Animator>();
  }

  private void FixedUpdate()
  {
    _input.player.mover.performed += context => OnMover(context);
    _input.player.mover.canceled += context => OffMover(context);
    _rb.velocity = _direction * _speed;
    if (_rb.velocity.x != 0)
    {
      state = states.walk;
      if (_rb.velocity.x > 0)
      {
        GetComponent<SpriteRenderer>().flipX = false;
      }
      else
      {
        GetComponent<SpriteRenderer>().flipX = true;
      }
    }
    else
      state = states.idle;
  }

  private void OnMover(InputAction.CallbackContext context)
  {
    StartCoroutine(accel_move());
    _direction = context.ReadValue<Vector2>();
  }

  private void OffMover(InputAction.CallbackContext context)
  {
    _speed = 0f;
    _direction = Vector2.zero;
  }

  private IEnumerator accel_move()
  {
    yield return new WaitForSeconds(0.12f);
    if (_speed <= _max_speed)
    {
      _speed += _acceleration;
      StartCoroutine(accel_move());
    }
    else
      StopCoroutine(accel_move());
  }

  enum states
  {
    idle,
    walk
  }
}
