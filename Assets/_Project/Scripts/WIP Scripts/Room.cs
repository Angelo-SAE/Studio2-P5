using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [SerializeField] private GameObject parentObject;
    public bool northD,southD,eastD,westD;
    public GameObject playerObj;

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
      }
    }

    private void OnTriggerExit(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        playerObj = null;
      }
    }
}
