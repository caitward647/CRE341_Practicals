using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureCount : MonoBehaviour
{
    public GameObject UiText;
    public GameObject CageFloor;

    public NPCRunAwayFromPlayer npcRun;
    void Start()
    {
        //Debug.Log(" UI False");
        UiText.SetActive(true);
        npcRun = GetComponent<NPCRunAwayFromPlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CageFloor")
        {
            //Debug.Log("npc enter cage");
            NPCManager.instance.npcCount++;
            npcRun.pauseAllMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CageFloor")
        {
            // Debug.Log("npc exit cage");
            NPCManager.instance.npcCount--;

            //stop rat wandering here
            npcRun.Wander();
        }
    }
}
