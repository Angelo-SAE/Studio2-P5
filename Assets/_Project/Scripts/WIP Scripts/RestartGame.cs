using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private List<Room> rooms = new List<Room>();

    public void RestartGameFunction()
    {
      OpenDoor.keyList = new List<int>();
      Tablet.hasTablet = false;
      foreach(Room room in rooms)
      {
        room.RemovePlayer();
      }
    }
}
