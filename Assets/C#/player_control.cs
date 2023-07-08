using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_control : MonoBehaviour
{
  private InputSystem _input;
  private Vector3 _input_direction;
  private int _direction = 0;
  private bool _jumped;
  private bool _on_jump = false;
  private float _jumped_distance = 0;
  private Animator anim;
  private float _speed;
  private float _max_speed;
  private float _min_speed;
  private float _acceleration;

  private void Awake()
  {
    _input = new InputSystem();
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
    _min_speed = 0.6f;
    _acceleration = _min_speed;
    _speed = _min_speed;
    _max_speed = _speed * 2;
    anim = GetComponent<Animator>();
  }

  private void GetIdle(int direction)
  {
    switch (direction)
    {
      case 0:
        state = states.idle;
        GetComponent<SpriteRenderer>().flipX = false;
        break;
      case 1:
        state = states.idle;
        GetComponent<SpriteRenderer>().flipX = true;
        break;
      case 2:
        state = states.idle_down;
        break;
      case 3:
        state = states.idle_up;
        break;
    }
  }

  private void GetJump(int direction)
  {
    switch (direction)
    {
      case 0:
        state = states.jump;
        GetComponent<SpriteRenderer>().flipX = false;
        break;
      case 1:
        state = states.jump;
        GetComponent<SpriteRenderer>().flipX = true;
        break;
      case 2:
        state = states.jump_down;
        break;
      case 3:
        state = states.jump_up;
        break;
    }
  }

  private void GetMoved()
  {
    transform.position = Vector3.MoveTowards(transform.position, transform.position + _input_direction, _speed * Time.deltaTime);
    if (_input_direction.x > 0)
    {
      state = states.walk;
      GetComponent<SpriteRenderer>().flipX = false;
      _direction = 0;
    }
    else if(_input_direction.x < 0)
    {
      state = states.walk;
      GetComponent<SpriteRenderer>().flipX = true;
      _direction = 1;
    }
    if(_input_direction.y < 0)
    {
      state = states.walk_down;
      _direction = 2;
    }
    else if(_input_direction.y > 0)
    {
      state = states.walk_up;
      _direction = 3;
    }
  }

  private void JumpProcess()
  {
    if (!_on_jump)
    {
      if (_jumped_distance < 0.6f)
      {
        _jumped_distance += 0.10f;
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.10f);
      }
      else if (_jumped_distance >= 0.6f)
        _on_jump = true;
    }
    else if (_on_jump)
    {
      if (_jumped_distance > 0f)
      {
        _jumped_distance -= 0.10f;
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.10f);
      }
      if (_jumped_distance <= 0f)
      {
        _on_jump = false;
        _jumped = false;
      }
    }
  }

  private void FixedUpdate()
  {
    if(_jumped)
    {
      JumpProcess();
    }
  }

  private void Update()
  {
    if (!_jumped && _input_direction == Vector3.zero) GetIdle(_direction);
    if (_jumped) GetJump(_direction);
    if (!_jumped && _input_direction != Vector3.zero) GetMoved();
    _input.player.mover.performed += context => OnMover(context);
    _input.player.mover.canceled += context => OffMover(context);
    _input.player.jump.performed += context => OnJump(context);
  }

  private void OnJump(InputAction.CallbackContext context)
  {
    _jumped = true;
  }

  private void OnMover(InputAction.CallbackContext context)
  {
    StartCoroutine(AccelMove());
    _input_direction = context.ReadValue<Vector2>();
  }

  private void OffMover(InputAction.CallbackContext context)
  {
    _speed = 0f;
    _input_direction = Vector2.zero;
  }


  private IEnumerator AccelMove()
  {
    while (_speed <= _max_speed)
    {
      yield return new WaitForSeconds(0.12f);
      _speed += _acceleration;
    }
  }

  enum states
  {
    idle,
    idle_down,
    idle_up,
    jump,
    jump_down,
    jump_up,
    sit,
    sit_down,
    sit_up,
    walk,
    walk_down,
    walk_up
  }
}
