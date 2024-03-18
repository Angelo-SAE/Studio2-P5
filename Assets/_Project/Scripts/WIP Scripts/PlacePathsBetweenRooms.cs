using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePathsBetweenRooms : MonoBehaviour
{
    private bool checkedForHalls;
    [SerializeField] private GameObject hallway1, hallway2, hallwayBlock1, hallwayBlock2;
    private GameObject hallHolder;

    void Update()
    {
      if(Mode.mode3D && !checkedForHalls)
      {
        checkedForHalls = true;
        CheckForAndCreateHalls();
      } else if(!Mode.mode3D && checkedForHalls)
      {
        checkedForHalls = false;
      }
    }

    private void CheckForAndCreateHalls()
    {
      if(hallHolder is not null)
      {
        Destroy(hallHolder);
      }
      hallHolder = new GameObject("Hall Holder");
      for(int a = 0; a < RoomSpots.roomSpots.GetLength(0); a++)
      {
        for(int b = 0; b < RoomSpots.roomSpots.GetLength(1) - 1; b++)
        {
          if(RoomSpots.roomSpots[a, b] is not null && RoomSpots.roomSpots[a, b + 1] is not null)
          {
            if(RoomSpots.roomSpots[a, b].GetComponent<RoomHolder>().northD && RoomSpots.roomSpots[a, b + 1].GetComponent<RoomHolder>().southD)
            {
              RoomSpots.roomSpots[a, b].GetComponent<RoomHolder>().northDOpen = true;
              RoomSpots.roomSpots[a, b + 1].GetComponent<RoomHolder>().southDOpen = true;
              Instantiate(hallway1, new Vector3(a * 23f, 0f, (b + 1f) * 23f), hallway1.transform.rotation, hallHolder.transform);
            } else {
              Instantiate(hallwayBlock1, new Vector3(a * 23f, 0f, (b + 1f) * 23f), hallway1.transform.rotation, hallHolder.transform);
            }
          } else if(RoomSpots.roomSpots[a, b] is not null || RoomSpots.roomSpots[a, b + 1] is not null)
          {
            Instantiate(hallwayBlock1, new Vector3(a * 23f, 0f, (b + 1f) * 23f), hallway1.transform.rotation, hallHolder.transform);
          }
        }
      }
      for(int b = 0; b < RoomSpots.roomSpots.GetLength(1); b++)
      {
        for(int a = 0; a < RoomSpots.roomSpots.GetLength(0) - 1; a++)
        {
          if(RoomSpots.roomSpots[a, b] is not null && RoomSpots.roomSpots[a + 1, b] is not null)
          {
            if(RoomSpots.roomSpots[a, b].GetComponent<RoomHolder>().eastD && RoomSpots.roomSpots[a + 1, b].GetComponent<RoomHolder>().westD)
            {
              RoomSpots.roomSpots[a, b].GetComponent<RoomHolder>().eastDOpen = true;
              RoomSpots.roomSpots[a + 1, b].GetComponent<RoomHolder>().westDOpen = true;
              Instantiate(hallway2, new Vector3((a + 1) * 23f, 0f, b * 23f), hallway2.transform.rotation, hallHolder.transform);
            } else {
              Instantiate(hallwayBlock2, new Vector3((a + 1) * 23f, 0f, b * 23f), hallway2.transform.rotation, hallHolder.transform);
            }
          } else if(RoomSpots.roomSpots[a, b] is not null || RoomSpots.roomSpots[a + 1, b] is not null)
          {
            Instantiate(hallwayBlock2, new Vector3((a + 1) * 23f, 0f, b * 23f), hallway2.transform.rotation, hallHolder.transform);
          }
        }
      }
    }
}
