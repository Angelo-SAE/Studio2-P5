using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyTypes
{
    blueKey,
    redKey
}

public class Interactable : MonoBehaviour
{
    [SerializeField] KeyTypes keyTypes;

    RaycastHit interactableHit;

    [SerializeField] float rayLength;

    [SerializeField] LayerMask interactable;

    public static GameObject interactableObject;

    [SerializeField] List<GameObject> collectedObj = new List<GameObject>();


    void DetectLayerInteractable()
    {
        Physics.Raycast(transform.position, transform.forward, out interactableHit, rayLength, interactable);        
        if(interactableHit.transform is not null)
        {
            Debug.Log("Interactable layert detecetd");
            GameObject hitObj = interactableHit.collider.gameObject;
           
            if (hitObj.CompareTag("Key"))
            {
                Debug.Log("Key detected");
                if(Input.GetMouseButtonDown(0))
                {
                    collectedObj.Add(hitObj);
                    hitObj.SetActive(false);
                }
            }
        }
        
        else 
        {
          interactableObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        DetectLayerInteractable();
    }
}
