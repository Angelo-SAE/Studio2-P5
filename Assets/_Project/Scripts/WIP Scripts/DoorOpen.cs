using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public string keyColor;
    public int keyNumber;
    public bool needsKey;
    public bool canOpen;
    private bool closedDoors;

    void Update()
    {
      if(Mode.mode3D && !closedDoors)
      {
        closedDoors = true;
        CloseOpenDoors();
      } else if(!Mode.mode3D && closedDoors)
      {
        closedDoors = false;
      }
    }

    public void OpenDoor()
    {
      if(canOpen)
      {
        Debug.Log("DoorOpened");
      }
    }

    private void CheckIfCanOpen()
    {

    }

    private void CloseOpenDoors()
    {

    }
}
