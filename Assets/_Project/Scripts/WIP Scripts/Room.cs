using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

  [SerializeField] private GameObject parentObject;



    void Update()
    {
      if(Mode.mode3D)
      {
        CheckAndUpdatePosition();
      }
    }

    private void CheckAndUpdatePosition()
    {
        transform.position = new Vector3(parentObject.transform.position.x, 0f,parentObject.transform.position.y);
    }
}
