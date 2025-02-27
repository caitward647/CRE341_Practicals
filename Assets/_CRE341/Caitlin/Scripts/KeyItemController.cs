using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace KeysSystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool cage = false;
        [SerializeField] private bool CageKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;
        public GameObject keyHeld;
        
        public CageController cageController;

        private void Start()
        {
            if (cageController == null)
            {
                cageController = GetComponent<CageController>();
            }
        }


        //if more keys are needed, ADD MORE HERE :)
        public void ObjectInteraction()
        {
         //   Debug.Log("Object Interaction");
            if (cageController)
            {
          //      Debug.Log("Play animation cage");
                cageController.PlayAnimation();
            }

             if (CageKey)
            {
                //set game object true in hand
                keyHeld.SetActive(true);
                _keyInventory.hasCageKey = true;
                gameObject.SetActive(false);
          //      Debug.Log("Have key");
            }
        }
    }
}