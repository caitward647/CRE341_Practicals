using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureCount : MonoBehaviour
{
    public GameObject UiText;
    public GameObject CageFloor;
    void Start()
    {
        Debug.Log(" UI False");
        UiText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with cage floor");
      //  if (gameObject.tag == "CageFloor")
      if (other.gameObject.tag == "CageFloor")
        {
            UiText.SetActive(true);
            Debug.Log("UI active");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
