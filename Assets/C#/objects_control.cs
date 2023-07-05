using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects_control : MonoBehaviour
{
  public GameObject[] objects;
  public Transform player;
  private Vector3 _current_player_pos;

  private void Start()
  {
    _current_player_pos = player.position;
  }

  private void Update()
  {
    if(_current_player_pos != player.position)
    {
      objects_update();
      _current_player_pos = player.position;
    }
  }

  private void objects_update()
  {
    foreach(GameObject obj in objects)
    {
      float a = obj.transform.position.y - player.position.y;
      if(a < -0.2f)
        obj.GetComponent<SpriteRenderer>().sortingOrder = 6;
      else if(a > 0.2f)
        obj.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
  }
}
