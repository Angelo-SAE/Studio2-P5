using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePathsBetweenRooms : MonoBehaviour
{
    private bool checkedForHalls;
    [SerializeField] private GameObject hallway;
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
      for(int b = 0; b < RoomSpots.roomSpots.GetLength(1) - 1; b++)
      {
        if(RoomSpots.roomSpots[a, b] is not null && RoomSpots.roomSpots[a, b + 1] is not null)
        {
          if(RoomSpots.roomSpots[a, b].GetComponent<RoomHolder>().northD && RoomSpots.roomSpots[a, b + 1].GetComponent<RoomHolder>().southD)
          {
            RoomSpots.roomSpots[a, b].GetComponent<RoomHolder>().northDOpen = true;
            RoomSpots.roomSpots[a, b + 1].GetComponent<RoomHolder>().southDOpen = true;
            Instantiate(hallway, new Vector3(a * 18f, 0f, (b + 1)* 18), hallway.transform.rotation, hallHolder.transform);
          }
        }
      }
    }
}
