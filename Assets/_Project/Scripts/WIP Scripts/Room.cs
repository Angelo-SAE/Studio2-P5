using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [SerializeField] private GameObject parentObject;
    public bool northD,southD,eastD,westD;
    public GameObject playerObj;
    public bool hasPlayer;

    void Awake()
    {
      Mode.AddRoom(this);
    }

    void Update()
    {
      if(Mode.mode3D)
      {
        CheckAndUpdatePosition();
      }
    }

    private void CheckAndUpdatePosition()
    {
        transform.position = new Vector3(parentObject.transform.position.x * 23f, 0f,parentObject.transform.position.y * 23f);
    }

    private void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        playerObj = col.gameObject;
        hasPlayer = true;
      }
    }

    private void OnTriggerExit(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        RemovePlayer();
      }
    }

    public void RemovePlayer()
    {
      playerObj = null;
      hasPlayer = false;
    }
}
