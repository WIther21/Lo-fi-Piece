using System.Collections;
using UnityEngine;

public class player_seat : MonoBehaviour
{
  [SerializeField] private bool _sit_direction;
  private Animator _anim;
  private player_control _player;
  private Vector2 _start_pos;
  private bool _is_sitting;

  private void Update()
  {
    if (_player == null)
      return;
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (_is_sitting)
        StandUp();
      else
        SitDown();
    }
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (_player == null)
      _player = collision.GetComponent<player_control>();
    if (_anim == null)
      _anim = collision.GetComponent<Animator>();
    _anim.SetBool("SitDirection", _sit_direction);
  }

  private void SitDown()
  {
    _is_sitting = true;
    _player.GetComponent<Collider2D>().enabled = false;
    _start_pos = _player.transform.position;
    _player.Sit();
    _player.transform.position = transform.position;
  }

  private void StandUp()
  {
    _player.transform.position = (Vector3)_start_pos;
    _player.GetComponent<Collider2D>().enabled = true;
    _player.Sit();
    _is_sitting = false;
    _player = null;
  }
}
