using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureCount : MonoBehaviour
{
    public GameObject UiText;

  //  public GameObject CageFloor;

   // public NPCRunAwayFromPlayer npcRun;

    public GameObject CageFloor;
    void Start()
    {
        //Debug.Log(" UI False");
        UiText.SetActive(true);
       // npcRun = GetComponent<NPCRunAwayFromPlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "CageFloor")
        {
            //Debug.Log("npc enter cage");
            NPCManager.instance.npcCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CageFloor")
        {
           // Debug.Log("npc exit cage");
            NPCManager.instance.npcCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
