using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{

    public static bool mode3D;

    public static List<Room> rooms = new List<Room>();

    void Awake()
    {
      mode3D = true;
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.R) && Tablet.hasTablet && !GameManager.isPaused)
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
          GameManager.canPause = false;
          mode3D = false;
        } else {
          GameManager.canPause = true;
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
