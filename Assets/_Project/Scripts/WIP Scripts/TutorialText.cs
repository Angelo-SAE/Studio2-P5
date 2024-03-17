using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public static string textText;

    private TMP_Text textBox;

    void Awake()
    {
      textBox = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
      textBox.text = textText;
      StartCoroutine(DeactivateObject());
    }

    private IEnumerator DeactivateObject()
    {
      yield return new WaitForSeconds(2f);
      gameObject.SetActive(false);
    }
}
