using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureCount : MonoBehaviour
{
    public GameObject UiText;
<<<<<<< HEAD
  //  public GameObject CageFloor;

   // public NPCRunAwayFromPlayer npcRun;
=======
    public GameObject CageFloor;
>>>>>>> parent of 4bbbb32 (A lot is broken)
    void Start()
    {
        //Debug.Log(" UI False");
        UiText.SetActive(true);
<<<<<<< HEAD
       // npcRun = GetComponent<NPCRunAwayFromPlayer>();
=======
>>>>>>> parent of 4bbbb32 (A lot is broken)
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "CageFloor")
        {
            //Debug.Log("npc enter cage");
            NPCManager.instance.npcCount++;
<<<<<<< HEAD
         //   npcRun.pauseAllMovement();
=======
>>>>>>> parent of 4bbbb32 (A lot is broken)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CageFloor")
        {
           // Debug.Log("npc exit cage");
            NPCManager.instance.npcCount--;
<<<<<<< HEAD

            //stop rat wandering here
           // npcRun.Wander();
=======
>>>>>>> parent of 4bbbb32 (A lot is broken)
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
