using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class player_jump : MonoBehaviour
{
  [SerializeField] private Vector2 _jump_distance;
  [SerializeField] private AnimationCurve _jump_fx;
  private float _animation_speed;
  private Animator _anim;
  private Vector2 _start_pos;
  private Vector2 _direction;
  private PlayerController _player;
  private bool _in_jumping;

  private void Awake()
  {
    _player = GetComponent<PlayerController>();
    _anim = GetComponent<Animator>();
  }

  public void JumpUpdate()
  {
    if(Input.GetKeyDown(KeyCode.Space) && !_in_jumping)
    {
      //_direction = _player.GetDirection(_direction);
      StartCoroutine(JumpAnimation(_direction));
    }
  }

  public bool GetJump(bool jump_state)
  {
    jump_state = _in_jumping;
    return jump_state;
  }

  public void SetAnimation()
  {
    _anim.SetBool("inJumping", _in_jumping);
  }

  private IEnumerator JumpAnimation(Vector2 direction)
  {
    _start_pos = _player.transform.position;
    _player.GetComponent<Collider2D>().enabled = false;
    Vector2 jump_pos = _start_pos;
    float current_time = 0;
    float total_time = _jump_fx.keys[_jump_fx.keys.Length - 1].time;
    _animation_speed = 1.4f;
    _in_jumping = true;
    if (direction != Vector2.zero)
    {
      jump_pos = _start_pos + _jump_distance * direction;
      total_time *= 1.25f;
      _animation_speed = 1.8f;
    }
      
    while (_in_jumping)
    {
      current_time += Time.deltaTime;
      float offset_y = _jump_fx.Evaluate(current_time);
      float pos_y = transform.position.y + offset_y;
      _player.transform.position = new Vector2(_player.transform.position.x, pos_y);
      _player.transform.position = Vector2.MoveTowards(_player.transform.position, jump_pos, _animation_speed * Time.deltaTime);
      yield return null;
      if (current_time >= total_time)
      {
        _player.GetComponent<Collider2D>().enabled = true;
        _in_jumping = !_in_jumping;
      }
    }
  }
}