using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool canDrag;

    [SerializeField] private Room room;

    void Update()
    {
      if(room.hasPlayer)
      {
        canDrag = false;
      } else {
        canDrag = true;
      }
    }
}
