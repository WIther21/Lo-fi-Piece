using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
  public Transform player;
  public Vector3 camera_pos;

  private void Update()
  {
    camera_pos.x = player.position.x;
    camera_pos.y = player.position.y;
    camera_pos.z = -10f;
    transform.position = camera_pos;
  }
}
