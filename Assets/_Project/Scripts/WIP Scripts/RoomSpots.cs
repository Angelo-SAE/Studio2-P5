using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpots : MonoBehaviour
{

    public static GameObject[,] roomSpots;
    [SerializeField] private GameObject[] startingRooms;


    void Start()
    {
      roomSpots = new GameObject[3,4];
      SetDefaultRooms();
    }

    void Update()
    {

    }

    private void SetDefaultRooms()
    {
      roomSpots[0,0] = startingRooms[0];
      roomSpots[0,1] = startingRooms[1];
      roomSpots[0,2] = startingRooms[2];
      roomSpots[1,0] = startingRooms[3];
      roomSpots[1,1] = startingRooms[4];
      roomSpots[1,2] = startingRooms[5];
      roomSpots[2,1] = startingRooms[6];
      roomSpots[2,2] = startingRooms[7];
      roomSpots[0,3] = startingRooms[8];
    }
}
