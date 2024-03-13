using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Collider col;

    void Start()
    {
      col = GetComponentInChildren<Collider>();
    }
}
