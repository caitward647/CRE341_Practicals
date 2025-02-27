using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeysSystem
{
    public class CageController : MonoBehaviour
    {
        private Animator cageAnim;
        private bool cageOpen = false;

        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClosed";

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showCageLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;
        public GameObject keyHeld;

        private void Awake()
        {
            cageAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseCageInteraction()
        {
       //     Debug.Log("Pause Cage Interaction");
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
       //     Debug.Log("Play Animation");
            if (_keyInventory.hasCageKey)
            {
         //       Debug.Log("Has key");
                if (!cageOpen && !pauseInteraction)
                {
                    keyHeld.SetActive(false);

                    //           Debug.Log("cage is open");
                    cageAnim.Play(openAnimationName, 0, 0.0f);
                    cageOpen = true;
                    StartCoroutine(PauseCageInteraction());
                }
             else if (cageOpen && !pauseInteraction) 
             {
                 cageAnim.Play(closeAnimationName, 0, 0.0f);
                 cageOpen =false;
                  StartCoroutine(PauseCageInteraction());
             } 
            
            }
            else
            {
         //       Debug.Log("No key");
                StartCoroutine(ShowCageLocked());
            }
        }

        IEnumerator ShowCageLocked()
        {
            showCageLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showCageLockedUI.SetActive(false);
        }
    }
}