using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureCount : MonoBehaviour
{
    public GameObject uiText;

  //  public GameObject CageFloor;

   // public NPCRunAwayFromPlayer npcRun;

    public GameObject CageFloor;
    void Start()
    {
        if (uiText == null)
        {
            uiText = GameObject.FindGameObjectWithTag("UIText");
        }
           if (uiText == null)
        {
            uiText = GameObject.FindGameObjectWithTag("CageFloor");
        }
        //Debug.Log(" UI False");
        uiText.SetActive(true);
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
