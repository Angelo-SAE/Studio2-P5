using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactivateTimer : MonoBehaviour
{
    public static string textText;

    [SerializeField] private TMP_Text textbox;

    void OnEnable()
    {
      StartCoroutine(DeactivateObject());
    }

    private IEnumerator DeactivateObject()
    {
      yield return new WaitForSeconds(4f);
      gameObject.SetActive(false);
    }
}
