using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHolder : MonoBehaviour
{
    public bool northD,southD,eastD,westD, northDOpen, southDOpen, eastDOpen, westDOpen, closedOpens;
    [SerializeField] private DoorOpen nDoor, sDoor, eDoor, wDoor;

    void Update()
    {
      if(Mode.mode3D && !closedOpens)
      {
        closedOpens = true;
        Invoke("SetDoorStatus", 0.1f);
      } else if(!Mode.mode3D && closedOpens)
      {
        closedOpens = false;
        ClosedOpens();
      }
    }

    private void ClosedOpens()
    {
      northDOpen = false;
      southDOpen = false;
      eastDOpen = false;
      westDOpen = false;
    }

    private void SetDoorStatus()
    {
      if(nDoor is not null)
      {
        nDoor.canOpen = northDOpen;
      }
      if(sDoor is not null)
      {
        sDoor.canOpen = southDOpen;
      }
      if(eDoor is not null)
      {
        eDoor.canOpen = eastDOpen;
      }
      if(wDoor is not null)
      {
        wDoor.canOpen = westDOpen;
      }
    }
}
