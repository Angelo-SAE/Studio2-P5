using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{

    public static bool mode3D;

    public static List<Room> rooms = new List<Room>();

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.R))
      {
        ChangeMode();
      }
    }

    private void ChangeMode()
    {
      if(CheckIfCanChangeMode())
      {
        if(mode3D)
        {
          mode3D = false;
        } else {
          mode3D = true;
        }
      }
    }

    private bool CheckIfCanChangeMode()
    {
      foreach(Room room in rooms)
      {
        if(room.hasPlayer)
        {
          return true;
        }
      }
      return false;
    }

    public static void AddRoom(Room room)
    {
      rooms.Add(room);
    }
}
